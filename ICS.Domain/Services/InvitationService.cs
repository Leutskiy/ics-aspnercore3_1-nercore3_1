using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Enums;
using ICS.Domain.Models;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using System.Collections.Generic;

namespace ICS.Domain.Services
{
    /// <summary>
    /// Сервис для работы с приглашениями
    /// </summary>
    public sealed class InvitationService : IInvitationService
    {
        private readonly IClock _clock;
        private readonly IUserInfoProvider _userContextPrtovider;
        private readonly IInvitationRepository _invitationRepository;
        private readonly IAlienService _alienService;
        private readonly IEmployeeService _employeeService;
        private readonly IVisitDetailService _visitDetailService;
        private readonly IForeignParticipantService _foreignParticipantService;

        public InvitationService(
            IClock clock,
            IUserInfoProvider userContextPrtovider,
            IInvitationRepository invitationRepository,
            IAlienService alienService,
            IEmployeeService employeeService,
            IVisitDetailService visitDetailService,
            IForeignParticipantService foreignParticipantService)
        {
            Contract.Argument.IsNotNull(clock, nameof(clock));
            Contract.Argument.IsNotNull(userContextPrtovider, nameof(userContextPrtovider));
            Contract.Argument.IsNotNull(invitationRepository, nameof(invitationRepository));
            Contract.Argument.IsNotNull(alienService, nameof(alienService));
            Contract.Argument.IsNotNull(employeeService, nameof(employeeService));
            Contract.Argument.IsNotNull(visitDetailService, nameof(visitDetailService));
            Contract.Argument.IsNotNull(foreignParticipantService, nameof(foreignParticipantService));

            _clock = clock;
            _userContextPrtovider = userContextPrtovider;
            _invitationRepository = invitationRepository;
            _alienService = alienService;
            _employeeService = employeeService;
            _visitDetailService = visitDetailService;
            _foreignParticipantService = foreignParticipantService;
        }

        /// <summary>
        /// Добавить приглашение
        /// </summary>
        /// <param name="addedInvitation">Добавляемое приглашение</param>
        /// <returns>Приглашение</returns>
        public Invitation Add(InvitationDto addedInvitation)
        {
            Contract.Argument.IsNotNull(addedInvitation, nameof(addedInvitation));

            var alien = _alienService.Add(addedInvitation.Alien);
            var employee = _employeeService.Add(addedInvitation.Employee);
            var visitDetail = _visitDetailService.Add(addedInvitation.VisitDetail);

            var foreignParticipants = new List<ForeignParticipant>();
            foreach (var foreignParticipantDto in addedInvitation.ForeignParticipants)
            {
                var foreignParticipant = _foreignParticipantService.Add(foreignParticipantDto);
            }

            var now = _clock.Now();

            var invitation = _invitationRepository.Create(
                alienId: alien.Id,
                employeeId: employee.Id,
                visitDetailId: visitDetail.Id,
                foreignParticipants: foreignParticipants,
                createdDate: now,
                updateDate: now,
                invitationStatus: InvitationStatus.Creating);

            return invitation;
        }

        public void Edit(InvitationDto editedInvitation)
        {

        }
    }
}