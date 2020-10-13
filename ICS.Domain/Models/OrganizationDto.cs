namespace ICS.Domain.Models
{
    /// <summary>
    /// DTO организации
    /// </summary>
    public sealed class OrganizationDto
    {
        /// <summary>
        /// DTO государственной регистрации
        /// </summary>
        public StateRegistrationDto StateRegistration { get; set; }

        /// <summary>
        /// Полное наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Краткое наименование
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Юридический адрес
        /// </summary>
        public string LegalAddress { get; set; }

        /// <summary>
        /// Направление научной деятельности
        /// </summary>
        public string ScientificActivity { get; set; }
    }
}