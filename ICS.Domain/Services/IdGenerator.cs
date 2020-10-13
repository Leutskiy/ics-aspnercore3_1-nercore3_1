using ICS.Domain.Services.Contracts;
using System;

namespace ICS.Domain.Services
{
    /// <summary>
    /// Генератор идентификаторов
    /// </summary>
    public sealed class IdGenerator : IIdGenerator
    {
        public Guid Generate()
        {
            return Guid.NewGuid();
        }
    }
}