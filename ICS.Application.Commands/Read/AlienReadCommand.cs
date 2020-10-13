using ICS.Domain.Data.Repositories.Contracts;
using ICS.Shared;
using ICS.WebApplication.Commands.Converters;
using ICS.WebApplication.Commands.Read.Contracts;
using ICS.WebApplication.Commands.Read.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.WebApplication.Commands.Read
{
    /// <summary>
    /// Команда чтения иностранцев
    /// </summary>
    public sealed class AlienReadCommand : IReadCommand<AlienResult>
    {
        private readonly IAlienRepository _alienRepository;
        private readonly IReadCommand<ContactResult> _contactReadCommand;
        private readonly IReadCommand<PassportResult> _passportReadCommand;
        private readonly IReadCommand<OrganizationResult> _organizationReadCommand;
        private readonly IReadCommand<StateRegistrationResult> _stateRegistrationReadCommand;

        public AlienReadCommand(
            IAlienRepository alienRepository,
            IReadCommand<ContactResult> contactReadCommand,
            IReadCommand<PassportResult> passportReadCommand,
            IReadCommand<OrganizationResult> organizationReadCommand,
            IReadCommand<StateRegistrationResult> stateRegistrationReadCommand)
        {
            Contract.Argument.IsNotNull(alienRepository, nameof(alienRepository));
            Contract.Argument.IsNotNull(contactReadCommand, nameof(contactReadCommand));
            Contract.Argument.IsNotNull(passportReadCommand, nameof(passportReadCommand));
            Contract.Argument.IsNotNull(organizationReadCommand, nameof(organizationReadCommand));
            Contract.Argument.IsNotNull(stateRegistrationReadCommand, nameof(stateRegistrationReadCommand));

            _alienRepository = alienRepository;
            _contactReadCommand = contactReadCommand;
            _passportReadCommand = passportReadCommand;
            _organizationReadCommand = organizationReadCommand;
            _stateRegistrationReadCommand = stateRegistrationReadCommand;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="alienId">Идентификатор иностранца</param>
        /// <returns>Информация об иностранце</returns>
        public async Task<AlienResult> ExecuteAsync(Guid alienId)
        {
            Contract.Argument.IsNotEmptyGuid(alienId, nameof(alienId));

            var alien = await _alienRepository.GetAsync(alienId).ConfigureAwait(false);

            var contactResult = await _contactReadCommand.ExecuteAsync(alien.ContactId).ConfigureAwait(false);
            var passportResult = await _passportReadCommand.ExecuteAsync(alien.PassportId).ConfigureAwait(false);
            var organizationResult = await _organizationReadCommand.ExecuteAsync(alien.OrganizationId).ConfigureAwait(false);
            var stateRegistrationResult = await _stateRegistrationReadCommand.ExecuteAsync(alien.StateRegistrationId).ConfigureAwait(false);

            return DomainEntityConverter.ConvertToResult(
                alien: alien,
                contactResult: contactResult,
                passportResult: passportResult,
                organizationResult: organizationResult,
                stateRegistrationResult: stateRegistrationResult);
        }

        public Task<IEnumerable<AlienResult>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}