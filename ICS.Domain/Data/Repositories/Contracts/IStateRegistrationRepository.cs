using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IStateRegistrationRepository
    {
        StateRegistration Create();

        StateRegistration Add(StateRegistrationDto addedStateRegistration);

        Task DeleteAsync(Guid id);

        Task<List<StateRegistration>> GetAllAsync();

        Task<StateRegistration> GetAsync(Guid id);

        Task UpdateAsync(Guid currentStateRegistrationId, StateRegistrationDto stateRegistrationDto);
    }
}