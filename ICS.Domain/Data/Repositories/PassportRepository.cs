using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Enums;
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
    /// Репозиторий паспортных данных
    /// </summary>
    public sealed class PassportRepository : IPassportRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainContext _domainContext;

        public PassportRepository(
            IIdGenerator idGenerator,
            DomainContext databaseContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _domainContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        /// <summary>
        /// Получить все паспортные данные
        /// </summary>
        /// <returns>Паспортные данные</returns>
        public async Task<IEnumerable<Passport>> GetAllAsync()
        {
            var passports = await _domainContext.Set<Passport>().ToArrayAsync().ConfigureAwait(false);

            return passports;
        }

        /// <summary>
        /// Получить паспортные данные по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор паспортных данных</param>
        /// <returns>Паспортные данные</returns>
        public async Task<Passport> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var passport = await _domainContext.Set<Passport>().FindAsync(id).ConfigureAwait(false);

            if (passport == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return passport;
        }

        /// <summary>
        /// Создать паспортные данные
        /// </summary>
        /// <param name="nameRus">Имя по-русски</param>
        /// <param name="nameEng">Имя по-английски</param>
        /// <param name="surnameRus">Фамилия по-русски</param>
        /// <param name="surnameEng">Фамилия по-английски</param>
        /// <param name="patronymicNameRus">Отчество по-русски</param>
        /// <param name="patronymicNameEng">Отчество по-английски</param>
        /// <param name="birthPlace">Место рождения</param>
        /// <param name="birthCountry">Страна рождения</param>
        /// <param name="citizenship">Гражданство (подданство)</param>
        /// <param name="residence">Местожительство</param>
        /// <param name="residenceCountry">Страна проживания</param>
        /// <param name="residenceRegion">Регион проживания</param>
        /// <param name="identityDocument">Документ идентифицирующий личность</param>
        /// <param name="issuePlace">Место выдачи документа</param>
        /// <param name="departmentCode">Код подразделения, выдававшего документ</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="issueDate">Дата выдачи</param>
        /// <param name="gender">Пол</param>
        /// <returns>Идентификатор паспортных данных</returns>
        public Passport Create(
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
            Sex? gender)
        {
            /*
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameRus, nameof(nameRus));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameEng, nameof(nameEng));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(surnameRus, nameof(surnameRus));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(surnameEng, nameof(surnameEng));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(patronymicNameRus, nameof(patronymicNameRus));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(patronymicNameEng, nameof(patronymicNameEng));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(birthPlace, nameof(birthPlace));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(birthCountry, nameof(birthCountry));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(departmentCode, nameof(departmentCode));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(citizenship, nameof(citizenship));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(identityDocument, nameof(identityDocument));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residence, nameof(residence));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residenceCountry, nameof(residenceCountry));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residenceRegion, nameof(residenceRegion));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(issuePlace, nameof(issuePlace));
            */

            var createdPassport = _domainContext.Set<Passport>().CreateProxy();

            var id = _idGenerator.Generate();
            createdPassport.Initialize(
                id: id,
                nameRus: nameRus,
                surnameRus: surnameRus,
                nameEng: nameEng,
                surnameEng: surnameEng,
                patronymicNameRus: patronymicNameRus,
                patronymicNameEng: patronymicNameEng,
                birthPlace: birthPlace,
                birthCountry: birthCountry,
                departmentCode: departmentCode,
                citizenship: citizenship,
                identityDocument: identityDocument,
                residence: residence,
                residenceCountry: residenceCountry,
                residenceRegion: residenceRegion,
                issuePlace: issuePlace,
                birthDate: birthDate,
                issueDate: issueDate,
                gender: gender);

            var newPassport = _domainContext.Set<Passport>().Add(createdPassport);

            return newPassport.Entity;
        }

        public async Task UpdateAsync(Guid currentPassportId, PassportDto newPassport)
        {
            Contract.Argument.IsNotEmptyGuid(currentPassportId, nameof(currentPassportId));
            Contract.Argument.IsNotNull(newPassport, nameof(newPassport));

            var currentPassport = await GetAsync(currentPassportId).ConfigureAwait(false);

            currentPassport.Update(
                nameRus: newPassport.NameRus,
                surnameRus: newPassport.SurnameRus,
                nameEng: newPassport.NameEng,
                surnameEng: newPassport.SurnameEng,
                patronymicNameRus: newPassport.PatronymicNameRus,
                patronymicNameEng: newPassport.PatronymicNameEng,
                birthPlace: newPassport.BirthPlace,
                birthCountry: newPassport.BirthCountry,
                departmentCode: newPassport.DepartmentCode,
                citizenship: newPassport.Citizenship,
                identityDocument: newPassport.IdentityDocument,
                residence: newPassport.Residence,
                residenceCountry: newPassport.ResidenceCountry,
                residenceRegion: newPassport.ResidenceRegion,
                issuePlace: newPassport.IssuePlace,
                birthDate: newPassport.BirthDate,
                issueDate: newPassport.IssueDate,
                gender: newPassport.Gender);
        }

        /// <summary>
        /// Удалить паспортные данные
        /// </summary>
        /// <param name="id">Идентификатор паспортных данных</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var deletedPassport = await GetAsync(id).ConfigureAwait(false);

            _domainContext.Set<Passport>().Remove(deletedPassport);
        }
    }
}