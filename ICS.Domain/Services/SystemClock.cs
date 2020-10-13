using ICS.Domain.Services.Contracts;
using System;

namespace ICS.Domain.Services
{
    public sealed class SystemClock : IClock
    {
        public DateTimeOffset Now()
        {
            return DateTimeOffset.UtcNow;
        }
    }
}