using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IForeignParticipantRepository
    {
        ForeignParticipant Create(
            Guid alienId,
            Guid passportId,
            Guid invitationId);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<ForeignParticipant>> GetAllAsync();

        Task<ForeignParticipant> GetAsync(Guid id);
    }
}