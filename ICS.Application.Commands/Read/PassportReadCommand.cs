﻿using ICS.Domain.Data.Repositories.Contracts;
using ICS.WebApplication.Commands.Converters;
using ICS.WebApplication.Commands.Read.Contracts;
using ICS.WebApplication.Commands.Read.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.WebApplication.Commands.Read
{
    /// <summary>
    /// Команда чтения паспортных данных
    /// </summary>
    public sealed class PassportReadCommand : IReadCommand<PassportResult>
    {
        private readonly IPassportRepository _passportRepository;

        public PassportReadCommand(IPassportRepository passportRepository)
        {
            _passportRepository = passportRepository;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="passportId">Идентификатор паспортных данных</param>
        /// <returns>Информация о паспорте</returns>
        public async Task<PassportResult> ExecuteAsync(Guid passportId)
        {
            var passport = await _passportRepository.GetAsync(passportId);

            return DomainEntityConverter.ConvertToResult(passport: passport);
        }

        public Task<IEnumerable<PassportResult>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}