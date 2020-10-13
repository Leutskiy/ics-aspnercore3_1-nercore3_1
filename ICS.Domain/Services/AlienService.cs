using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Models;
using ICS.Domain.Services.Contracts;
using ICS.Shared;

namespace ICS.Domain.Services
{
    /// <summary>
    /// Сервис по работе с иностранцами
    /// </summary>
    public sealed class AlienService : IAlienService
    {
        private readonly IContactService _contactService;
        private readonly IPassportService _passportService;
        private readonly IOrganizationService _organizationService;
        private readonly IStateRegistrationService _stateRegistrationService;
        private readonly IAlienRepository _alienRepository;

        public AlienService(
            IContactService contactService,
            IPassportService passportService,
            IOrganizationService organizationService,
            IStateRegistrationService stateRegistrationService,
            IAlienRepository alienRepository)
        {
            Contract.Argument.IsNotNull(contactService, nameof(contactService));
            Contract.Argument.IsNotNull(passportService, nameof(passportService));
            Contract.Argument.IsNotNull(organizationService, nameof(organizationService));
            Contract.Argument.IsNotNull(stateRegistrationService, nameof(stateRegistrationService));
            Contract.Argument.IsNotNull(alienRepository, nameof(alienRepository));

            _contactService = contactService;
            _passportService = passportService;
            _organizationService = organizationService;
            _stateRegistrationService = stateRegistrationService;
            _alienRepository = alienRepository;
        }

        /// <summary>
        /// Добавить иностранца
        /// </summary>
        /// <param name="addedAlien">DTO добавляемого иностранца</param>
        public Alien Add(AlienDto addedAlien)
        {
            Contract.Argument.IsNotNull(addedAlien, nameof(addedAlien));

            var alienContact = _contactService.Add(addedAlien.Contact);
            var alienPassport = _passportService.Add(addedAlien.Passport);
            var alienOrganization = _organizationService.Add(addedAlien.Organization);
            var alienStateRegistration = _stateRegistrationService.Add(addedAlien.StateRegistration);

            var alien = _alienRepository.Create(
                invitationId: addedAlien.InvitationId,
                contactId: alienContact.Id,
                passportId: alienPassport.Id,
                organizationId: alienOrganization.Id,
                stateRegistrationId: alienStateRegistration.Id,
                position: addedAlien.Position,
                workPlace: addedAlien.WorkPlace,
                workAddress: addedAlien.WorkAddress,
                stayAddress: addedAlien.StayAddress);

            return alien;
        }
    }
}