using Newtonsoft.Json;

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
        [JsonProperty("academicRank")]
        public string? AcademicRank { get; set; }

        /// <summary>
        /// Научная степень
        /// </summary>
        [JsonProperty("academicDegree")]
        public string? AcademicDegree { get; set; }

        /// <summary>
        /// Образование
        /// </summary>
        [JsonProperty("education")]
        public string? Education { get; set; }
    }
}