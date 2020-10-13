using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Models;
using ICS.Domain.Services.Contracts;
using ICS.Shared;

namespace ICS.Domain.Services
{
    /// <summary>
    /// Сервис по работе с государственной регистрацией
    /// </summary>
    public sealed class StateRegistrationService : IStateRegistrationService
    {
        private readonly IStateRegistrationRepository _stateRegistrationRepository;

        public StateRegistrationService(
            IStateRegistrationRepository stateRegistrationRepository)
        {
            Contract.Argument.IsNotNull(stateRegistrationRepository, nameof(stateRegistrationRepository));

            _stateRegistrationRepository = stateRegistrationRepository;
        }

        /// <summary>
        /// Добавить государственную регистрацию
        /// </summary>
        /// <param name="addedStateRegistration">Добавляемая государственная регистрация</param>
        /// <returns>Государственная регистрация</returns>
        public StateRegistration Add(StateRegistrationDto addedStateRegistration)
        {
            Contract.Argument.IsNotNull(addedStateRegistration, nameof(addedStateRegistration));

            var stateRegistration = _stateRegistrationRepository.Create(
                inn: addedStateRegistration.Inn,
                ogrnip: addedStateRegistration.Ogrnip);

            return stateRegistration;
        }
    }
}