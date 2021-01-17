using ICS.Domain.Data.Repositories.Contracts;
using ICS.WebApplication.Commands.Converters;
using ICS.WebApplication.Commands.Read.Contracts;
using ICS.WebApplication.Commands.Read.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.WebApplication.Commands.Read
{
	/// <summary>
	/// Команда чтения государственных регистраций
	/// </summary>
	public sealed class StateRegistrationReadCommand : IReadCommand<StateRegistrationResult>
    {
        private readonly IStateRegistrationRepository _stateRegistrationRepository;

        public StateRegistrationReadCommand(IStateRegistrationRepository stateRegistrationRepository)
        {
            _stateRegistrationRepository = stateRegistrationRepository;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="stateRegistrationId">Идентификатор государственной регистрации</param>
        /// <returns>Информация об госудраственной регистрации</returns>
        public async Task<StateRegistrationResult> ExecuteAsync(Guid stateRegistrationId)
        {
            var stateRegistration = await _stateRegistrationRepository.GetAsync(stateRegistrationId);

            return DomainEntityConverter.ConvertToResult(stateRegistration: stateRegistration);
        }

        public Task<IEnumerable<StateRegistrationResult>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}