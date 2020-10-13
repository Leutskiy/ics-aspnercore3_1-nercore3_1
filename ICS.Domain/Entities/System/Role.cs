using System;

namespace ICS.Domain.Entities.System
{
    /// <summary>
    /// Роль
    /// </summary>
    public sealed class Role
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Имя роли
        /// </summary>
        public string RoleName { get; private set; }
    }
}