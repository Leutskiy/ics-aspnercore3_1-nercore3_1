using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IAlienRepository
    {
        Alien Create();

        Alien Add(InviteeDto addedAlien);

        Task DeleteAsync(Guid id);

        Task<List<Alien>> GetAllAsync();

        Task<Alien> GetAsync(Guid id);
    }
}