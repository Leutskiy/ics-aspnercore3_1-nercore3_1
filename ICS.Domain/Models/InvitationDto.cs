using System.Collections.Generic;

namespace ICS.Domain.Models
{
    /// <summary>
    /// DTO приглашения
    /// </summary>
    public sealed class InvitationDto
    {
        /// <summary>
        /// DTO иностранца
        /// </summary>
        public AlienDto Alien { get; set; }

        /// <summary>
        /// DTO сотрудника
        /// </summary>
        public EmployeeDto Employee { get; set; }

        /// <summary>
        /// DTO деталей визита
        /// </summary>
        public VisitDetailDto VisitDetail { get; set; }

        /// <summary>
        /// Коллекция DTOs иностранного сопровождения сопровождения
        /// </summary>
        public IEnumerable<ForeignParticipantDto> ForeignParticipants { get; set; }
    }
}