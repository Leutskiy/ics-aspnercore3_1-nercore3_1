using System;

namespace ICS.Domain.Models
{
    /// <summary>
    /// DTO иностранца
    /// </summary>
    public sealed class AlienDto
    {
        /// <summary>
        /// Идентификатор приглашения
        /// </summary>
        public Guid InvitationId { get; set; }

        /// <summary>
        /// DTO контактных даннх
        /// </summary>
        public ContactDto Contact { get; set; }

        /// <summary>
        /// DTO паспортных данных
        /// </summary>
        public PassportDto Passport { get; set; }

        /// <summary>
        /// DTO организации
        /// </summary>
        public OrganizationDto Organization { get; set; }

        /// <summary>
        /// DTO государственной регистрации
        /// </summary>
        public StateRegistrationDto StateRegistration { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Место работы
        /// </summary>
        public string WorkPlace { get; set; }

        /// <summary>
        /// Адрес работы
        /// </summary>
        public string WorkAddress { get; set; }

        /// <summary>
        /// Адрес пребывания
        /// </summary>
        public string StayAddress { get; set; }
    }
}