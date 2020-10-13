using ICS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Приглашение
    /// </summary>
    public class Invitation
    {
        protected Invitation()
        {
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Идентификатор иностранца
        /// </summary>
        public virtual Guid AlienId { get; protected set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public virtual Guid EmployeeId { get; protected set; }

        /// <summary>
        /// Идентификатор деталей поездки по приглашению
        /// </summary>
        public virtual Guid VisitDetailId { get; protected set; }

        /// <summary>
        /// Сопровождение
        /// </summary>
        public virtual List<ForeignParticipant> ForeignParticipants { get; protected set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public virtual DateTimeOffset CreatedDate { get; protected set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public virtual DateTimeOffset UpdateDate { get; protected set; }

        /// <summary>
        /// Статус
        /// </summary>
        public virtual InvitationStatus Status { get; protected set; }

        /// <summary>
        /// Инициализировать приглашение
        /// </summary>
        internal void Initialize(
            Guid id,
            Guid alienId,
            Guid employeeId,
            Guid visitDetailId,
            ICollection<ForeignParticipant> foreignParticipants,
            DateTimeOffset createdDate,
            DateTimeOffset updateDate,
            InvitationStatus invitationStatus)
        {
            /*Contract.Argument.IsValidIf(Id != id, $"{Id} (current) != {id} (new)");
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsValidIf(createdDate <= updateDate, $"{nameof(createdDate)}:{createdDate} < {nameof(updateDate)}:{updateDate}");
            Contract.Argument.IsNotEmptyGuid(alienId, nameof(alienId));
            Contract.Argument.IsNotEmptyGuid(employeeId, nameof(employeeId));
            Contract.Argument.IsNotEmptyGuid(visitDetailId, nameof(visitDetailId));*/

            Id = id;

            SetAlienId(alienId);
            SetEmployeeId(employeeId);
            SetVisitDetailId(visitDetailId);
            SetForeignParticipants(foreignParticipants);
            SetCreatedDate(createdDate);
            SetUpdateDate(updateDate);
            SetInvitationStatus(invitationStatus);
        }

        /// <summary>
        /// Задать приглашенного иностраца
        /// </summary>
        /// <param name="alienId">Инстранец</param>
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
        /// Задать сотрудника
        /// </summary>
        /// <param name="employeeId">Сотрудник</param>
        internal void SetEmployeeId(Guid employeeId)
        {
            //Contract.Argument.IsNotEmptyGuid(employeeId, nameof(employeeId));

            if (EmployeeId == employeeId)
            {
                return;
            }

            EmployeeId = employeeId;
        }

        /// <summary>
        /// Задать детали визита
        /// </summary>
        /// <param name="visitDetailId">Детали визита</param>
        internal void SetVisitDetailId(Guid visitDetailId)
        {
            //Contract.Argument.IsNotEmptyGuid(visitDetailId, nameof(visitDetailId));

            if (VisitDetailId == visitDetailId)
            {
                return;
            }

            VisitDetailId = visitDetailId;
        }

        /// <summary>
        /// Задать дату создания
        /// </summary>
        /// <param name="createdDate">Дата создания</param>
        internal void SetCreatedDate(DateTimeOffset createdDate)
        {
            if (CreatedDate == createdDate)
            {
                return;
            }

            CreatedDate = createdDate;
        }

        /// <summary>
        /// Задать дату обновления
        /// </summary>
        /// <param name="updateDate">Дата обновления</param>
        internal void SetUpdateDate(DateTimeOffset updateDate)
        {
            if (UpdateDate == updateDate)
            {
                return;
            }

            UpdateDate = updateDate;
        }

        /// <summary>
        /// Задать статус приглашения
        /// </summary>
        /// <param name="invitationStatus">Статус приглашения</param>
        internal void SetInvitationStatus(InvitationStatus invitationStatus)
        {
            if (Status == invitationStatus)
            {
                return;
            }

            Status = invitationStatus;
        }

        /// <summary>
        /// Добавить сопровождающего иностранца-участника
        /// </summary>
        /// <param name="foreignParticipant">Иностранный участник</param>
        internal void AddForeignParticipant(ForeignParticipant foreignParticipant)
        {
            if (ForeignParticipants.Any(fp => fp.Id == foreignParticipant.Id))
            {
                return;
            }

            ForeignParticipants.Add(foreignParticipant);
        }

        /// <summary>
        /// Добавить сопровождающих иностранцев-участников
        /// </summary>
        /// <param name="foreignParticipant">Инострацы участники</param>
        internal void AddForeignParticipants(params ForeignParticipant[] foreignParticipants)
        {
            /*Contract.Argument.IsNotNull(foreignParticipants, nameof(foreignParticipants));
            Contract.Implementation.IsNotNull(ForeignParticipants, nameof(ForeignParticipants));*/

            foreach (var foreignParticipant in foreignParticipants)
            {
                if (!ForeignParticipants.Any(fp => fp.Id == foreignParticipant.Id))
                {
                    ForeignParticipants.Add(foreignParticipant);
                }
            }
        }

        /// <summary>
        /// Задать иностранное сопровождения
        /// </summary>
        /// <param name="foreignParticipants">Иностранное сопровождение</param>
        private void SetForeignParticipants(ICollection<ForeignParticipant> foreignParticipants)
        {
            ForeignParticipants = ForeignParticipants ?? new List<ForeignParticipant>();

            AddForeignParticipants(foreignParticipants.ToArray());
        }
    }
}