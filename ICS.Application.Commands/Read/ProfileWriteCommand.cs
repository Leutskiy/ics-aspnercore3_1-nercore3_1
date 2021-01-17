﻿using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Models;
using System;
using System.Threading.Tasks;

namespace ICS.WebApplication.Commands.Read
{
	/// <summary>
	/// Команда персистенса информации по профилю пользователя
	/// </summary>
	public sealed class ProfileWriteCommand
    {
        private readonly IProfileRepository _profileRepository;
        private readonly SystemContext _systemContext;

        public ProfileWriteCommand(
            IProfileRepository profileRepository,
            SystemContext systemContext)
        {
            _profileRepository = profileRepository;
            _systemContext = systemContext;
        }

        /// <summary>
        /// Выполнить команду Обновить профиль
        /// </summary>
        /// <param name="profileId">Идентификатор профиля</param>
        /// <param name="profileDto">Данные по профилю</param>
        public async Task UpdateAsync(Guid profileId, ProfileDto profileDto)
        {
            await _profileRepository.UpdateAsync(profileId, profileDto);

            await _systemContext.SaveChangesAsync();
        }
    }
}
