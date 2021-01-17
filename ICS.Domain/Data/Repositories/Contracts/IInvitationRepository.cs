using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IInvitationRepository
    {
        Invitation Create(Alien alien, Employee employee);

        Invitation Add(Employee employee, InvitationDto addedInvitation);

        Task DeleteAsync(Guid id);

        Task<List<Invitation>> GetAllAsync();

        Task<Invitation> GetAsync(Guid id);
    }
}