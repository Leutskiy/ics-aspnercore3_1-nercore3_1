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
    /// Команда чтения организаций
    /// </summary>
    public sealed class OrganizationReadCommand : IReadCommand<OrganizationResult>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IReadCommand<StateRegistrationResult> _stateRegistrationReadCommand;

        public OrganizationReadCommand(
            IOrganizationRepository organizationRepository,
            IReadCommand<StateRegistrationResult> stateRegistrationReadCommand)
        {
            Contract.Argument.IsNotNull(organizationRepository, nameof(organizationRepository));
            Contract.Argument.IsNotNull(stateRegistrationReadCommand, nameof(stateRegistrationReadCommand));

            _organizationRepository = organizationRepository;
            _stateRegistrationReadCommand = stateRegistrationReadCommand;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="organizationId">Идентификатор организации</param>
        /// <returns>Информация об организации</returns>
        public async Task<OrganizationResult> ExecuteAsync(Guid organizationId)
        {
            Contract.Argument.IsNotEmptyGuid(organizationId, nameof(organizationId));

            var organization = await _organizationRepository.GetAsync(organizationId).ConfigureAwait(false);
            var stateRegistrationResult = await _stateRegistrationReadCommand.ExecuteAsync(organization.StateRegistrationId).ConfigureAwait(false);

            return DomainEntityConverter.ConvertToResult(
                organization: organization,
                stateRegistrationResult: stateRegistrationResult);
        }

        public Task<IEnumerable<OrganizationResult>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}