using ICS.Domain.Data.Repositories.Contracts;
using ICS.Shared;
using ICS.WebApplication.Commands.Converters;
using ICS.WebApplication.Commands.Read.Contracts;
using ICS.WebApplication.Commands.Read.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICS.WebApplication.Commands.Read
{
    /// <summary>
    /// Команда чтения приглашений
    /// </summary>
    public sealed class InvitationReadCommand : IReadCommand<InvitationResult>
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly IReadCommand<AlienResult> _alienReadCommand;
        private readonly IReadCommand<EmployeeResult> _employeeReadCommand;
        private readonly IReadCommand<VisitDetailResult> _visitDetailReadCommand;
        private readonly ForeignParticipantReadCommand _foreignParticipantReadCommand;

        public InvitationReadCommand(
            IInvitationRepository invitationRepository,
            IReadCommand<AlienResult> alienReadCommand,
            IReadCommand<EmployeeResult> employeeReadCommand,
            IReadCommand<VisitDetailResult> visitDetailReadCommand,
            ForeignParticipantReadCommand foreignParticipantReadCommand)
        {
            Contract.Argument.IsNotNull(invitationRepository, nameof(invitationRepository));
            Contract.Argument.IsNotNull(alienReadCommand, nameof(alienReadCommand));
            Contract.Argument.IsNotNull(employeeReadCommand, nameof(employeeReadCommand));
            Contract.Argument.IsNotNull(visitDetailReadCommand, nameof(visitDetailReadCommand));
            Contract.Argument.IsNotNull(foreignParticipantReadCommand, nameof(foreignParticipantReadCommand));

            _invitationRepository = invitationRepository;
            _alienReadCommand = alienReadCommand;
            _employeeReadCommand = employeeReadCommand;
            _visitDetailReadCommand = visitDetailReadCommand;
            _foreignParticipantReadCommand = foreignParticipantReadCommand;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="invitationId">Идентификатор приглашения</param>
        /// <returns>Информация о приглашении</returns>
        public async Task<InvitationResult> ExecuteAsync(Guid invitationId)
        {
            Contract.Argument.IsNotEmptyGuid(invitationId, nameof(invitationId));

            var invitation = await _invitationRepository.GetAsync(invitationId).ConfigureAwait(false);

            var alienResult = await _alienReadCommand.ExecuteAsync(invitation.AlienId).ConfigureAwait(false);
            var employeeResult = await _employeeReadCommand.ExecuteAsync(invitation.EmployeeId).ConfigureAwait(false);
            var visitDetailResult = await _visitDetailReadCommand.ExecuteAsync(invitation.VisitDetailId).ConfigureAwait(false);

            var foreignParticipantIds = invitation.ForeignParticipants.Select(fp => fp.Id);
            var foreignParticipantResultCollection = await _foreignParticipantReadCommand.ExecuteAsync(foreignParticipantIds).ConfigureAwait(false);

            return DomainEntityConverter.ConvertToResult(
                invitation: invitation,
                alienResult: alienResult,
                employeeResult: employeeResult,
                visitDetailResult: visitDetailResult,
                foreignParticipantResultCollection: foreignParticipantResultCollection);
        }

        public async Task<IEnumerable<InvitationResult>> ExecuteAsync()
        {
            //TODO: переделать
            var invitations = await _invitationRepository.GetAllAsync().ConfigureAwait(false);

            var invitationResults = new List<InvitationResult>();

            foreach (var invitation in invitations)
            {
                var invitationResult = await ExecuteAsync(invitation.Id).ConfigureAwait(false);
                invitationResults.Add(invitationResult);
            }

            return invitationResults;
        }
    }
}