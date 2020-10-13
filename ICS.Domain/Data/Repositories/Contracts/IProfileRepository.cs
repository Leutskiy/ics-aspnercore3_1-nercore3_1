using System;
using System.Threading.Tasks;
using ICS.Domain.Entities.System;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IProfileRepository
    {
        Task<Profile> CreateAsync(User user);
        Task<Profile> GetAsync(Guid id);
        Task<Profile> GetByOrdinalNumberAsync(long ordinalNumber);
        Task UpdateAsync(Guid profileId, ProfileDto newProfileData);
    }
}