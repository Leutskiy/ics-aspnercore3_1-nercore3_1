using System;

namespace ICS.Domain.Services.Contracts
{
    public interface IUserInfoProvider
    {
        Guid GetUserId();
    }
}