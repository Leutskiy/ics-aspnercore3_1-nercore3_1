using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Enums;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IPassportRepository
    {
        Passport Create(
            string nameRus,
            string nameEng,
            string surnameRus,
            string surnameEng,
            string patronymicNameRus,
            string patronymicNameEng,
            string birthPlace,
            string birthCountry,
            string citizenship,
            string residence, 
            string residenceCountry,
            string residenceRegion,
            string identityDocument,
            string issuePlace,
            string departmentCode, 
            DateTime? birthDate,
            DateTime? issueDate,
            Sex? gender);

        Task UpdateAsync(Guid currentPassportId, PassportDto newPassport);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<Passport>> GetAllAsync();

        Task<Passport> GetAsync(Guid id);
    }
}