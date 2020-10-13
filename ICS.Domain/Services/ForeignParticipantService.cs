using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Models;
using ICS.Domain.Services.Contracts;
using ICS.Shared;

namespace ICS.Domain.Services
{
    /// <summary>
    /// Сервис для работы с иностранными участниками
    /// </summary>
    public sealed class ForeignParticipantService : IForeignParticipantService
    {
        private readonly IPassportService _passportService;
        private readonly IForeignParticipantRepository _foreignParticipantRepository;

        public ForeignParticipantService(
            IPassportService passportService,
            IForeignParticipantRepository foreignParticipantRepository)
        {
            Contract.Argument.IsNotNull(passportService, nameof(passportService));
            Contract.Argument.IsNotNull(foreignParticipantRepository, nameof(foreignParticipantRepository));

            _passportService = passportService;
            _foreignParticipantRepository = foreignParticipantRepository;
        }

        /// <summary>
        /// Добавить иностранного участника
        /// </summary>
        /// <param name="addedForeignParticipant">DTO добавляемого иностранного участника</param>
        /// <returns>Иностранный участник</returns>
        public ForeignParticipant Add(ForeignParticipantDto addedForeignParticipant)
        {
            Contract.Argument.IsNotNull(addedForeignParticipant, nameof(addedForeignParticipant));

            var foreignParticipantPassport = _passportService.Add(
                addedPassport: addedForeignParticipant.Passport);

            var foreignParticipant = _foreignParticipantRepository.Create(
                alienId: addedForeignParticipant.AlienId,
                invitationId: addedForeignParticipant.InvitationId,
                passportId: foreignParticipantPassport.Id);

            return foreignParticipant;
        }
    }
}