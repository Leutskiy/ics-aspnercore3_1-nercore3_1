namespace ICS.Domain.Models
{
    /// <summary>
    /// DTO государственной регистрации
    /// </summary>
    public sealed class StateRegistrationDto
    {
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