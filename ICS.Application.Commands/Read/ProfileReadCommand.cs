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
	/// Команда чтения профиля
	/// </summary>
	public sealed class ProfileReadCommand : IReadCommand<ProfileResult>
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileReadCommand(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="profileId">Идентификатор профиля</param>
        /// <returns>Информация о профиле</returns>
        public async Task<ProfileResult> ExecuteAsync(Guid profileId)
        {
            var profile = await _profileRepository.GetAsync(profileId);

            return DomainEntityConverter.ConvertToResult(profile: profile);
        }

        public Task<IEnumerable<ProfileResult>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}