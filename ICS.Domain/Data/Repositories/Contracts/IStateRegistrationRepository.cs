using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IStateRegistrationRepository
    {
        StateRegistration Create(string inn, string ogrnip);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<StateRegistration>> GetAllAsync();

        Task<StateRegistration> GetAsync(Guid id);

        Task UpdateAsync(Guid currentStateRegistrationId, StateRegistrationDto stateRegistrationDto);
    }
}