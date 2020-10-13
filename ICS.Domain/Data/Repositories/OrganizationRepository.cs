using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Models;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories
{
    /// <summary>
    /// Репозиторий организаций
    /// </summary>
    public sealed class OrganizationRepository : IOrganizationRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainContext _domainContext;

        public OrganizationRepository(
            IIdGenerator idGenerator,
            DomainContext databaseContext)
        {
            Contract.Argument.IsNotNull(idGenerator, nameof(idGenerator));
            Contract.Argument.IsNotNull(databaseContext, nameof(databaseContext));

            _idGenerator = idGenerator;
            _domainContext = databaseContext;
        }

        /// <summary>
        /// Получить все организации
        /// </summary>
        /// <returns>Организации</returns>
        public async Task<IEnumerable<Organization>> GetAllAsync()
        {
            var organizations = await _domainContext.Set<Organization>().ToArrayAsync().ConfigureAwait(false);

            return organizations;
        }

        /// <summary>
        /// Получить организацию по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор организации</param>
        /// <returns>Организация</returns>
        public async Task<Organization> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var organization = await _domainContext.Set<Organization>().FindAsync(id).ConfigureAwait(false);

            if (organization == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return organization;
        }

        /// <summary>
        /// Создать организацию
        /// </summary>
        /// <param name="stateRegistration">Государственная регистрация</param>
        /// <param name="name">Наименование</param>
        /// <param name="shortName">Короткое наименование</param>
        /// <param name="legalAddress">Юридический адрес</param>
        /// <param name="scientificActivity">Научная деятельность</param>
        /// <returns>Идентификатор организации</returns>
        public Organization Create(
            Guid stateRegistrationId,
            string name,
            string shortName,
            string legalAddress,
            string scientificActivity)
        {
            /*
            Contract.Argument.IsNotEmptyGuid(stateRegistrationId, nameof(stateRegistrationId));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(name, nameof(name));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(shortName, nameof(shortName));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(scientificActivity, nameof(scientificActivity));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(legalAddress, nameof(legalAddress));
            */

            var createdOrganization = _domainContext.Set<Organization>().CreateProxy();

            var id = _idGenerator.Generate();
            createdOrganization.Initialize(
                id: id,
                stateRegistrationId: stateRegistrationId,
                name: name,
                shortName: shortName,
                scientificActivity: scientificActivity,
                legalAddress: legalAddress);

            var newOrganization = _domainContext.Set<Organization>().Add(createdOrganization);

            return newOrganization.Entity;
        }

        /// <summary>
        /// Обновить организацию
        /// </summary>
        /// <param name="currentOrganizationId">Идентификатор обновляемой организации</param>
        /// <param name="organizationDto">Данные для полного обновления организации</param>
        public async Task UpdateAsync(
            Guid currentOrganizationId,
            OrganizationDto organizationDto)
        {
            Contract.Argument.IsNotEmptyGuid(currentOrganizationId, nameof(currentOrganizationId));
            Contract.Argument.IsNotNull(organizationDto, nameof(organizationDto));

            var currentOrganization = await GetAsync(currentOrganizationId).ConfigureAwait(false);

            currentOrganization.Update(
                name: organizationDto.Name,
                shortName: organizationDto.ShortName,
                scientificActivity: organizationDto.ScientificActivity,
                legalAddress: organizationDto.LegalAddress);
        }

        /// <summary>
        /// Удалить организацию
        /// </summary>
        /// <param name="id">Идентификатор организации</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var deletedOrganization = await GetAsync(id).ConfigureAwait(false);

            _domainContext.Set<Organization>().Remove(deletedOrganization);
        }
    }
}