namespace ICS.Domain.Models
{
    /// <summary>
    /// DTO контакта
    /// </summary>
    public sealed class ContactDto
    {
        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Индекс
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Домашний номер телефона
        /// </summary>
        public string HomePhoneNumber { get; set; }

        /// <summary>
        /// Рабочий номер телефона
        /// </summary>
        public string WorkPhoneNumber { get; set; }

        /// <summary>
        /// Мобильный номер телефона
        /// </summary>
        public string MobilePhoneNumber { get; set; }
    }
}