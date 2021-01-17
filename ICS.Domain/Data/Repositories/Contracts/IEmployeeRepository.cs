﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        Employee Create(Guid userId);

        Task DeleteAsync(Guid id);

        Task<List<Employee>> GetAllAsync();

        Task<Employee> GetAsync(Guid id);

        Task<Employee> GetByUserIdAsync(Guid userId);

        Task UpdateScientificInfoAsync(Guid employeeId, ScientificInfoDto scientificInfoDto);
        Task UpdateJobAsync(Guid employeeId, JobDto jobDto);
    }
}