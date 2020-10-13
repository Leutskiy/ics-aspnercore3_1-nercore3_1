using ICS.Domain.Entities;
using ICS.Domain.Models;

namespace ICS.Domain.Services.Contracts
{
    public interface IInvitationService
    {
        Invitation Add(InvitationDto addedInvitation);

        void Edit(InvitationDto editedInvitation);
    }
}