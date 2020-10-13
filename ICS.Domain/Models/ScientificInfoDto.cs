namespace ICS.Domain.Models
{
    /// <summary>
    /// DTO научной вовлеченности сотрудника
    /// </summary>
    public sealed class ScientificInfoDto
    {
        /// <summary>
        /// Научное звание
        /// </summary>
        public string AcademicRank { get; set; }

        /// <summary>
        /// Научная степень
        /// </summary>
        public string AcademicDegree { get; set; }

        /// <summary>
        /// Образование
        /// </summary>
        public string Education { get; set; }
    }
}