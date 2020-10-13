using System;

namespace ICS.WebApplication.Commands.Read.Results
{
    /// <summary>
    /// Данные по профилю
    /// </summary>
    public sealed class ProfileResult
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Аватарка
        /// </summary>
        public byte[] Avatar { get; set; }

        /// <summary>
        /// Web-страницы
        /// </summary>
        public string WebPages { get; set; }
    }
}