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
    /// Репозиторий регистраций государственных номеров
    /// </summary>
    public sealed class StateRegistrationRepository : IStateRegistrationRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainContext _domainContext;

        public StateRegistrationRepository(
            IIdGenerator idGenerator,
            DomainContext databaseContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _domainContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        /// <summary>
        /// Получить все государственные регистрации
        /// </summary>
        /// <returns>Государственные регистрации</returns>
        public async Task<IEnumerable<StateRegistration>> GetAllAsync()
        {
            var stateRegistrations = await _domainContext.Set<StateRegistration>().ToArrayAsync().ConfigureAwait(false);

            return stateRegistrations;
        }

        /// <summary>
        /// Получить государственные регистрации по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор государственной регистрации</param>
        /// <returns>Государственная регистрация</returns>
        public async Task<StateRegistration> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var stateRegistration = await _domainContext.Set<StateRegistration>().FindAsync(id).ConfigureAwait(false);

            if (stateRegistration == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return stateRegistration;
        }

        /// <summary>
        /// Создать государственную регистрацию
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <param name="ogrnip"><ОГРНИП/param>
        /// <returns>Идентификатор государственной регистрации</returns>
        public StateRegistration Create(
            string inn,
            string ogrnip)
        {
            /*
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(inn, nameof(inn));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(ogrnip, nameof(ogrnip));
            */

            var createdStateRegistration = _domainContext.Set<StateRegistration>().CreateProxy();

            var id = _idGenerator.Generate();
            createdStateRegistration.Initialize(
                id: id,
                inn: inn,
                ogrnip: ogrnip);

            var newStateRegistration = _domainContext.Set<StateRegistration>().Add(createdStateRegistration);

            return newStateRegistration.Entity;
        }

        /// <summary>
        /// Обновить государственную регистрацию
        /// </summary>
        /// <param name="currentStateRegistrationId">Идентификатор обновляемой государственной регистрации</param>
        /// <param name="stateRegistrationDto">Данные для полного обновления государственной регистрации</param>
        public async Task UpdateAsync(
            Guid currentStateRegistrationId,
            StateRegistrationDto stateRegistrationDto)
        {
            Contract.Argument.IsNotEmptyGuid(currentStateRegistrationId, nameof(currentStateRegistrationId));
            Contract.Argument.IsNotNull(stateRegistrationDto, nameof(stateRegistrationDto));

            var currentStateRegistration = await GetAsync(currentStateRegistrationId).ConfigureAwait(false);

            currentStateRegistration.Update(
                inn: stateRegistrationDto.Inn,
                ogrnip: stateRegistrationDto.Ogrnip);
        }

        /// <summary>
        /// Удалить государственную регистрацию
        /// </summary>
        /// <param name="id">Идентификатор государственной регистрации</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var deletedStateRegistration = await GetAsync(id).ConfigureAwait(false);

            _domainContext.Set<StateRegistration>().Remove(deletedStateRegistration);
        }
    }
}