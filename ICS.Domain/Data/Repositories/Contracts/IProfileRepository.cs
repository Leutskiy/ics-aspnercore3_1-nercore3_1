using System;
using System.Threading.Tasks;
using ICS.Domain.Entities.System;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IProfileRepository
    {
        Profile Create();

        Task<Profile> GetAsync(Guid id);

        Task<Profile[]> GetAllAsync();

        Task UpdateAsync(Guid profileId, ProfileDto newProfileData);
    }
}