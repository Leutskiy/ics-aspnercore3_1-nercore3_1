using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IAlienRepository
    {
        Alien Create(
            Guid invitationId,
            Guid contactId,
            Guid passportId,
            Guid organizationId,
            Guid stateRegistrationId,
            string position,
            string workPlace,
            string workAddress,
            string stayAddress);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<Alien>> GetAllAsync();

        Task<Alien> GetAsync(Guid id);
    }
}