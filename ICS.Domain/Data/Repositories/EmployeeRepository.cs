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
    /// Репозиторий сотрудников
    /// </summary>
    public sealed class EmployeeRepository : IEmployeeRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainContext _domainContext;

        public EmployeeRepository(
            IIdGenerator idGenerator,
            DomainContext databaseContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _domainContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        /// <summary>
        /// Получить всех сотрудников
        /// </summary>
        /// <returns><Сотрудники</returns>
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employees = await _domainContext.Set<Employee>().ToArrayAsync().ConfigureAwait(false);

            return employees;
        }

        /// <summary>
        /// Получить сотрудника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns>Сотрудник</returns>
        public async Task<Employee> GetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id));
            }

            var employee = await _domainContext.Set<Employee>().FirstOrDefaultAsync(empl => empl.Id == id).ConfigureAwait(false);

            if (employee == null)
            {
                throw new Exception($"Сотрудник для {id} не найден");
            }

            return employee;
        }

        /// <summary>
        /// Получить сотрудника по идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор сотрудника</param>
        /// <returns>Сотрудник</returns>
        public async Task<Employee> GetByUserIdAsync(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentException(nameof(userId));
            }

            var employee = await _domainContext.Set<Employee>().FirstOrDefaultAsync(empl => empl.UserId == userId).ConfigureAwait(false);

            if (employee == null)
            {
                throw new Exception($"Сущность не найдена для user id: {userId}");
            }

            return employee;
        }

        /// <summary>
        /// Создать сотрудника
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="managerId">Руководитель</param>
        /// <param name="contactId">Контактные данные</param>
        /// <param name="passportId">Паспортные данные</param>
        /// <param name="organizationId">Организация</param>
        /// <param name="stateRegistrationId">Государственная регистрация</param>
        /// <param name="workPlace">Место работы</param>
        /// <param name="position">Должность</param>
        /// <returns>Идентификатор сотрудника</returns>
        public Employee Create(
            Guid userId,
            Guid? managerId = null,
            Guid? invitationId = null,
            Guid? contactId = null,
            Guid? passportId = null,
            Guid? organizationId = null,
            Guid? stateRegistrationId = null,
            string academicDegree = null,
            string academicRank = null,
            string education = null,
            string workPlace = null,
            string position = null)
        {
            /*
            Contract.Argument.IsValidIf(userId != Guid.Empty, $"{userId} != Guid.Empty");
            Contract.Argument.IsValidIf(managerId != Guid.Empty, $"{managerId} != Guid.Empty");
            Contract.Argument.IsValidIf(invitationId != Guid.Empty, $"{invitationId} != Guid.Empty");
            Contract.Argument.IsValidIf(contactId != Guid.Empty, $"{contactId} != Guid.Empty");
            Contract.Argument.IsValidIf(passportId != Guid.Empty, $"{passportId} != Guid.Empty");
            Contract.Argument.IsValidIf(invitationId != Guid.Empty, $"{invitationId} != Guid.Empty");
            Contract.Argument.IsValidIf(organizationId != Guid.Empty, $"{organizationId} != Guid.Empty");
            Contract.Argument.IsValidIf(stateRegistrationId != Guid.Empty, $"{stateRegistrationId} != Guid.Empty");
            */


            var createdEmployee = _domainContext.Set<Employee>().CreateProxy();

            var id = _idGenerator.Generate();
            createdEmployee.Initialize(
                id: id,
                userId: userId,
                managerId: managerId,
                contactId: contactId,
                passportId: passportId,
                invitationId: invitationId,
                organizationId: organizationId,
                stateRegistrationId: stateRegistrationId,
                academicDegree: academicDegree,
                academicRank: academicRank,
                education: education,
                workPlace: workPlace,
                position: position);

            var newEmployee = _domainContext.Set<Employee>().Add(createdEmployee);

            return newEmployee.Entity;
        }

        /// <summary>
        /// Обновить данные по сотруднику
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="scientificInfoDto">Данные по сотруднику</param>
        public async Task UpdateScientificInfoAsync(Guid employeeId, ScientificInfoDto scientificInfoDto)
        {
            Contract.Argument.IsNotNull(scientificInfoDto, nameof(scientificInfoDto));

            var updatedEmployee = await GetAsync(employeeId).ConfigureAwait(false);

            updatedEmployee.SetAcademicDegree(scientificInfoDto.AcademicDegree);
            updatedEmployee.SetAcademicRank(scientificInfoDto.AcademicRank);
            updatedEmployee.SetEducation(scientificInfoDto.Education);
        }

        /// <summary>
        /// Обновить данные по сотруднику
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="jobDto">Данные по сотруднику</param>
        public async Task UpdateJobAsync(Guid employeeId, JobDto jobDto)
        {
            Contract.Argument.IsNotNull(jobDto, nameof(jobDto));

            var updatedEmployee = await GetAsync(employeeId).ConfigureAwait(false);

            updatedEmployee.SetWorkPlace(jobDto.WorkPlace);
            updatedEmployee.SetPosition(jobDto.Position);
        }

        /// <summary>
        /// Удалить сотрудника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var deletedEmployee = await GetAsync(id).ConfigureAwait(false);

            _domainContext.Set<Employee>().Remove(deletedEmployee);
        }
    }
}