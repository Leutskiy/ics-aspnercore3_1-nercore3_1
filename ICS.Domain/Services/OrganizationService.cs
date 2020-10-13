using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Models;
using ICS.Domain.Services.Contracts;
using ICS.Shared;

namespace ICS.Domain.Services
{
    /// <summary>
    /// Сервис для работы с организациями
    /// </summary>
    public sealed class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IStateRegistrationService _stateRegistrationService;

        public OrganizationService(
            IOrganizationRepository organizationRepository,
            IStateRegistrationService stateRegistrationService)
        {
            Contract.Argument.IsNotNull(organizationRepository, nameof(organizationRepository));
            Contract.Argument.IsNotNull(stateRegistrationService, nameof(stateRegistrationService));

            _organizationRepository = organizationRepository;
            _stateRegistrationService = stateRegistrationService;
        }

        /// <summary>
        /// Добавить организацию
        /// </summary>
        /// <param name="addedOrganization">DTO добавляемой организации</param>
        public Organization Add(OrganizationDto addedOrganization)
        {
            Contract.Argument.IsNotNull(addedOrganization, nameof(addedOrganization));

            var stateRegistration = _stateRegistrationService.Add(addedOrganization.StateRegistration);

            var organization = _organizationRepository.Create(
                stateRegistrationId: stateRegistration.Id,
                name: addedOrganization.Name,
                shortName: addedOrganization.ShortName,
                legalAddress: addedOrganization.LegalAddress,
                scientificActivity: addedOrganization.ScientificActivity);

            return organization;
        }
    }
}