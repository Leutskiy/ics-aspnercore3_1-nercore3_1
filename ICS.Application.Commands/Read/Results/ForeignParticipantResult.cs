using System;

namespace ICS.WebApplication.Commands.Read.Results
{
    /// <summary>
    /// Данные по иностранному участнику
    /// </summary>
    public sealed class ForeignParticipantResult
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор иностранца
        /// </summary>
        public Guid AlienId { get; set; }

        /// <summary>
        /// Идентификатор приглашения
        /// </summary>
        public Guid InvitationId { get; set; }

        /// <summary>
        /// Данные по паспорту
        /// </summary>
        public PassportResult Passport { get; set; }
    }
}