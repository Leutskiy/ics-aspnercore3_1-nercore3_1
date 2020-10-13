using ICS.Domain.Entities.System;
using System;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IUserRepository
    {
        User Create(string userName, string password, Profile profile = null);
        Task<User> Get(string userName, string password);
        Task<Guid> GetEmployeeId(Guid userId);
        Task<Guid> GetProfileId(Guid userId);
    }
}