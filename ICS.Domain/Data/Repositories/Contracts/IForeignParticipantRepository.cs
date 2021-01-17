using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IForeignParticipantRepository
    {
        ForeignParticipant Create();

        ForeignParticipant Add(ForeignParticipantDto addedForeignParticipant);

        Task DeleteAsync(Guid id);

        Task<List<ForeignParticipant>> GetAllAsync();

        Task<ForeignParticipant> GetAsync(Guid id);
    }
}