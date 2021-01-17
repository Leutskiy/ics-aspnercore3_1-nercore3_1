﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IOrganizationRepository
    {
        Organization Create();

        Organization Add(OrganizationDto addedOrganization);

        Task DeleteAsync(Guid id);

        Task<List<Organization>> GetAllAsync();

        Task<Organization> GetAsync(Guid id);

        Task UpdateAsync(Guid currentOrganizationId, OrganizationDto organizationDto);
    }
}