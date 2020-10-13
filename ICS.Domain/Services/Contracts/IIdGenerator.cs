using System;

namespace ICS.Domain.Services.Contracts
{
    public interface IIdGenerator
    {
        Guid Generate();
    }
}