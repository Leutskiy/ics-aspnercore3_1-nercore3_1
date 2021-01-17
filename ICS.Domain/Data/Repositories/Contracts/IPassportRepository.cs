using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories.Contracts
{
	public interface IPassportRepository
    {
        Passport Create();

        Passport Add(PassportDto addedPassport);

        Task UpdateAsync(Guid currentPassportId, PassportDto newPassport);

        Task DeleteAsync(Guid id);

        Task<List<Passport>> GetAllAsync();

        Task<Passport> GetAsync(Guid id);
    }
}