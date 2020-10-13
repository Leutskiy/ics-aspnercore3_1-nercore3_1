using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories
{
    /// <summary>
    /// Репозиторий иностранцев
    /// </summary>
    public sealed class AlienRepository : IAlienRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainContext _domainContext;

        public AlienRepository(
            IIdGenerator idGenerator,
            DomainContext databaseContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _domainContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        /// <summary>
        /// Получить всех иностранцев
        /// </summary>
        /// <returns>Иностранцы</returns>
        public async Task<IEnumerable<Alien>> GetAllAsync()
        {
            var aliens = await _domainContext.Set<Alien>().ToArrayAsync().ConfigureAwait(false);

            return aliens;
        }

        /// <summary>
        /// Получить иностранца
        /// </summary>
        /// <param name="id">Идентификатор иностранца</param>
        /// <returns>Иностранец</returns>
        public async Task<Alien> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var alien = await _domainContext.Set<Alien>().FindAsync(id).ConfigureAwait(false);

            if (alien == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return alien;
        }

        /// <summary>
        /// Создать иностранца
        /// </summary>
        /// <param name="contactId">Контакт</param>
        /// <param name="passportId">Паспорт</param>
        /// <param name="organizationId">Организация</param>
        /// <param name="stateRegistrationId">Государственная регистрация</param>
        /// <param name="position">Должность</param>
        /// <param name="workPlace">Место работы</param>
        /// <param name="workAddress">Рабочий адрес</param>
        /// <param name="stayAddress">Адрес пребывания</param>
        /// <returns>Идентификатор иностранца</returns>
        public Alien Create(
            Guid contactId,
            Guid passportId,
            Guid invitationId,
            Guid organizationId,
            Guid stateRegistrationId,
            string position,
            string workPlace,
            string workAddress,
            string stayAddress)
        {
            Contract.Argument.IsNotEmptyGuid(contactId, nameof(contactId));
            Contract.Argument.IsNotEmptyGuid(passportId, nameof(passportId));
            Contract.Argument.IsNotEmptyGuid(invitationId, nameof(invitationId));
            Contract.Argument.IsNotEmptyGuid(organizationId, nameof(organizationId));
            Contract.Argument.IsNotEmptyGuid(stateRegistrationId, nameof(stateRegistrationId));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(position, nameof(position));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workPlace, nameof(workPlace));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workAddress, nameof(workAddress));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(stayAddress, nameof(stayAddress));

            var createdAlien = _domainContext.Set<Alien>().CreateProxy();

            var id = _idGenerator.Generate();
            createdAlien.Initialize(
                id: id,
                contactId: contactId,
                passportId: passportId,
                invitationId: invitationId,
                organizationId: organizationId,
                stateRegistrationId: stateRegistrationId,
                position: position,
                workPlace: workPlace,
                workAddress: workAddress,
                stayAddress: stayAddress);

            var newAlien =_domainContext.Set<Alien>().Add(createdAlien);

            return newAlien.Entity;
        }

        /// <summary>
        /// Удалить иностранца
        /// </summary>
        /// <param name="id">Идентификатор иностранца</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var deletedAlien = await GetAsync(id).ConfigureAwait(false);

            _domainContext.Set<Alien>().Remove(deletedAlien);
        }
    }
}