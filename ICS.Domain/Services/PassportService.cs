using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Models;
using ICS.Domain.Services.Contracts;
using ICS.Shared;

namespace ICS.Domain.Services
{
    /// <summary>
    /// Сервис для работы с паспортными данными
    /// </summary>
    public sealed class PassportService : IPassportService
    {
        private readonly IPassportRepository _passportRepository;

        public PassportService(
            IPassportRepository passportRepository)
        {
            Contract.Argument.IsNotNull(passportRepository, nameof(passportRepository));

            _passportRepository = passportRepository;
        }

        /// <summary>
        /// Добавить паспортные данные
        /// </summary>
        /// <param name="addedPassport">DTO добавляемого паспорта</param>
        public Passport Add(PassportDto addedPassport)
        {
            Contract.Argument.IsNotNull(addedPassport, nameof(addedPassport));

            var passport = _passportRepository.Create(
                nameRus: addedPassport.NameRus,
                nameEng: addedPassport.NameEng,
                surnameRus: addedPassport.SurnameRus,
                surnameEng: addedPassport.SurnameEng,
                patronymicNameRus: addedPassport.PatronymicNameRus,
                patronymicNameEng: addedPassport.PatronymicNameEng,
                birthPlace: addedPassport.BirthPlace,
                birthCountry: addedPassport.BirthCountry,
                citizenship: addedPassport.Citizenship,
                residence: addedPassport.Residence,
                residenceCountry: addedPassport.ResidenceCountry,
                residenceRegion: addedPassport.ResidenceRegion,
                identityDocument: addedPassport.IdentityDocument,
                issuePlace: addedPassport.IssuePlace,
                departmentCode: addedPassport.DepartmentCode,
                birthDate: addedPassport.BirthDate,
                issueDate: addedPassport.IssueDate,
                gender: addedPassport.Gender);

            return passport;
        }
    }
}