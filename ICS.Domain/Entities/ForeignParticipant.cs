using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Иностранный сопровождающий
    /// </summary>
    public class ForeignParticipant
    {
        protected ForeignParticipant()
        {

        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Идентификатор сопровождаемого иностранца
        /// </summary>
        public virtual Guid AlienId { get; protected set; }

        /// <summary>
        /// Идентификатор паспорта
        /// </summary>
        public virtual Guid PassportId { get; protected set; }

        /// <summary>
        /// Идентификатор приглашения
        /// </summary>
        public virtual Guid InvitationId { get; protected set; }

        /// <summary>
        /// Инициализировать иностранного сопровождающего
        /// </summary>
        /// <param name="alienId">Идентификатор сопровождаемого иностранца</param>
        /// <param name="invitationId">Идентификатор приглашения</param>
        /// <param name="passportId">Паспортные данные</param>
        internal void Initialize(
            Guid id,
            Guid alienId,
            Guid invitationId,
            Guid passportId)
        {
            /*Contract.Argument.IsValidIf(Id != id, $"{Id} (current) != {id} (new)");
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotEmptyGuid(alienId, nameof(alienId));
            Contract.Argument.IsNotEmptyGuid(invitationId, nameof(invitationId));
            Contract.Argument.IsNotEmptyGuid(passportId, nameof(passportId));*/

            Id = id;

            SetAlienId(alienId);
            SetInvitationId(invitationId);
            SetPassportId(passportId);
        }

        /// <summary>
        /// Задать идентификатор иностранца
        /// </summary>
        /// <param name="alienId">Идентификатор иностранца</param>
        internal void SetAlienId(Guid alienId)
        {
            //Contract.Argument.IsNotEmptyGuid(alienId, nameof(alienId));

            if (AlienId == alienId)
            {
                return;
            }

            AlienId = alienId;
        }

        /// <summary>
        /// Задать идентификатор приглашения
        /// </summary>
        /// <param name="invitationId">Идентификатор приглашения</param>
        internal void SetInvitationId(Guid invitationId)
        {
            //Contract.Argument.IsNotEmptyGuid(invitationId, nameof(invitationId));

            if (InvitationId == invitationId)
            {
                return;
            }

            InvitationId = invitationId;
        }

        /// <summary>
        /// Задать паспортные данные
        /// </summary>
        /// <param name="passportId">Паспортные данные</param>
        internal void SetPassportId(Guid passportId)
        {
            //Contract.Argument.IsNotEmptyGuid(passportId, nameof(passportId));

            if (PassportId == passportId)
            {
                return;
            }

            PassportId = passportId;
        }
    }
}