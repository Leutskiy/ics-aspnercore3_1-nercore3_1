using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Enums;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IInvitationRepository
    {
        Invitation Create(
            Guid alienId,
            Guid employeeId,
            Guid visitDetailId,
            ICollection<ForeignParticipant> foreignParticipants,
            DateTimeOffset createdDate,
            DateTimeOffset updateDate,
            InvitationStatus invitationStatus);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<Invitation>> GetAllAsync();

        Task<Invitation> GetAsync(Guid id);
    }
}