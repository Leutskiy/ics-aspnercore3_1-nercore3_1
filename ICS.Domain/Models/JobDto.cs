namespace ICS.Domain.Models
{
    /// <summary>
    /// DTO работы сотрудника
    /// </summary>
    public sealed class JobDto
    {
        /// <summary>
        /// Место работы
        /// </summary>
        public string WorkPlace { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }
    }
}