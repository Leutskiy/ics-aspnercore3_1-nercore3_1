using System;

namespace ICS.Domain.Services.Contracts
{
    public interface IClock
    {
        DateTimeOffset Now();
    }
}