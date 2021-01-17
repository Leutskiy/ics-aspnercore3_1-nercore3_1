using ICS.Domain.Entities;
using ICS.Domain.Models;
using System;

namespace ICS.Domain.Services.Contracts
{
    [Obsolete]
    public interface IInvitationService
    {
        Invitation Add(Employee employee, InvitationDto addedInvitation);

        void Edit(InvitationDto editedInvitation);
    }
}