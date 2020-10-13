using System;

namespace ICS.WebApplication.Commands.Read.Results
{
    /// <summary>
    /// Данные по государственной регистрации
    /// </summary>
    public sealed class StateRegistrationResult
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// ОГРНИП
        /// </summary>
        public string Ogrnip { get; set; }
    }
}