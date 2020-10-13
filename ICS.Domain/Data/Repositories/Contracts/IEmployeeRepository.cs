using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        Employee Create(
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
            string position = null);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<Employee>> GetAllAsync();

        Task<Employee> GetAsync(Guid id);

        Task<Employee> GetByUserIdAsync(Guid userId);

        Task UpdateScientificInfoAsync(Guid employeeId, ScientificInfoDto scientificInfoDto);
        Task UpdateJobAsync(Guid employeeId, JobDto jobDto);
    }
}