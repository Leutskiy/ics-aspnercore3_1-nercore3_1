using ICS.Shared;
using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        protected Employee()
        {
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Идентификатор пользователя системы
        /// </summary>
        public virtual Guid UserId { get; protected set; }

        /// <summary>
        /// Идентификатор руководителя-сотрудника
        /// </summary>
        public virtual Guid? ManagerId { get; protected set; }

        /// <summary>
        /// Идентификатор приглашения
        /// </summary>
        public virtual Guid? InvitationId { get; protected set; }

        /// <summary>
        /// Идентификатор контактных данных
        /// </summary>
        public virtual Guid? ContactId { get; protected set; }

        /// <summary>
        /// Идентификатор паспорта
        /// </summary>
        public virtual Guid? PassportId { get; protected set; }

        /// <summary>
        /// Идентификатор организации
        /// </summary>
        public virtual Guid? OrganizationId { get; protected set; }

        /// <summary>
        /// Идентификатор государственной регистрации
        /// </summary>
        public virtual Guid? StateRegistrationId { get; protected set; }

        /// <summary>
        /// Рукодводитель
        /// </summary>
        public virtual Employee Manager { get; protected set; }

        /// <summary>
        /// Научная степень
        /// </summary>
        public virtual string AcademicDegree { get; protected set; }

        /// <summary>
        /// Научное звание
        /// </summary>
        public virtual string AcademicRank { get; protected set; }

        /// <summary>
        /// Образование
        /// </summary>
        public virtual string Education { get; protected set; }

        /// <summary>
        /// Место работы
        /// </summary>
        public virtual string WorkPlace { get; protected set; }

        /// <summary>
        /// Должность
        /// </summary>
        public virtual string Position { get; protected set; }

        /// <summary>
        /// Инициализировать сотрудника
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <param name="userId">Идентификатор пользователя системы</param>
        /// <param name="contactId">Контактные данные сотрудника</param>
        /// <param name="managerId">Руководитель сотрудника</param>
        /// <param name="passportId">Паспортные данные сотрудника</param>
        /// <param name="invitationId">Приглашение</param>
        /// <param name="organizationId">Организация</param>
        /// <param name="stateRegistrationId">Государственная регистрация</param>
        /// <param name="workPlace">Место работы сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        public void Initialize(
            Guid id,
            Guid userId,
            Guid? contactId,
            Guid? managerId,
            Guid? passportId,
            Guid? invitationId,
            Guid? organizationId,
            Guid? stateRegistrationId,
            string academicDegree,
            string academicRank,
            string education,
            string workPlace,
            string position)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsValidIf(Id != id, $"{Id} (current) != {id} (new)");
            Contract.Argument.IsValidIf(userId != Guid.Empty, $"{userId} != Guid.Empty");
            Contract.Argument.IsValidIf(managerId != Guid.Empty, $"{managerId} != Guid.Empty");
            Contract.Argument.IsValidIf(contactId != Guid.Empty, $"{contactId} != Guid.Empty");
            Contract.Argument.IsValidIf(passportId != Guid.Empty, $"{passportId} != Guid.Empty");
            Contract.Argument.IsValidIf(invitationId != Guid.Empty, $"{invitationId} != Guid.Empty");
            Contract.Argument.IsValidIf(organizationId != Guid.Empty, $"{organizationId} != Guid.Empty");
            Contract.Argument.IsValidIf(stateRegistrationId != Guid.Empty, $"{stateRegistrationId} != Guid.Empty");

            Id = id;

            SetUserId(userId);
            SetManagerId(managerId);
            SetInvitationId(invitationId);
            SetContactId(contactId);
            SetPassportId(passportId);
            SetOrganizationId(organizationId);
            SetStateRegistrationId(stateRegistrationId);
            SetWorkPlace(workPlace);
            SetPosition(position);
        }

        /// <summary>
        /// Задать идентификатор пользователя системы
        /// </summary>
        /// <param name="userId">Иденфтикатор пользователя системы</param>
        public void SetUserId(Guid userId)
        {
            Contract.Argument.IsValidIf(userId != Guid.Empty, $"{userId} != Guid.Empty");

            if (UserId == userId)
            {
                return;
            }

            UserId = userId;
        }

        /// <summary>
        /// Задать приглашение
        /// </summary>
        /// <param name="invitationId">Приглашение</param>
        public void SetInvitationId (Guid? invitationId)
        {
            //Contract.Argument.IsValidIf(invitationId != Guid.Empty, $"{invitationId} != Guid.Empty");

            if (InvitationId == invitationId)
            {
                return;
            }

            InvitationId = invitationId;
        }

        /// <summary>
        /// Задать руководителя
        /// </summary>
        /// <param name="managerId">Руководитель</param>
        public void SetManagerId(Guid? managerId)
        {
            //Contract.Argument.IsValidIf(managerId != Guid.Empty, $"{managerId} != Guid.Empty");

            if (ManagerId == managerId)
            {
                return;
            }

            ManagerId = managerId;
        }

        /// <summary>
        /// Задать контракт
        /// </summary>
        /// <param name="contactId">Контракт</param>
        public void SetContactId(Guid? contactId)
        {
            //Contract.Argument.IsValidIf(contactId != Guid.Empty, $"{contactId} != Guid.Empty");

            if (ContactId == contactId)
            {
                return;
            }

            ContactId = contactId;
        }

        /// <summary>
        /// Задать паспорт
        /// </summary>
        /// <param name="passportId">Паспорт</param>
        public void SetPassportId(Guid? passportId)
        {
            //Contract.Argument.IsValidIf(passportId != Guid.Empty, $"{passportId} != Guid.Empty");

            if (PassportId == passportId)
            {
                return;
            }

            PassportId = passportId;
        }

        /// <summary>
        /// Задать организацию
        /// </summary>
        /// <param name="organizationId">Организация</param>
        public void SetOrganizationId(Guid? organizationId)
        {
            //Contract.Argument.IsValidIf(organizationId != Guid.Empty, $"{organizationId} != Guid.Empty");

            if (OrganizationId == organizationId)
            {
                return;
            }

            OrganizationId = organizationId;
        }

        /// <summary>
        /// Задать государственные регистрационные номера
        /// </summary>
        /// <param name="stateRegistrationId">Государственные регистрационные номера</param>
        public void SetStateRegistrationId(Guid? stateRegistrationId)
        {
            //Contract.Argument.IsValidIf(stateRegistrationId != Guid.Empty, $"{stateRegistrationId} != Guid.Empty");

            if (StateRegistrationId == stateRegistrationId)
            {
                return;
            }

            StateRegistrationId = stateRegistrationId;
        }

        /// <summary>
        /// Задать научная степень
        /// </summary>
        /// <param name="academicDegree">Научная степень</param>
        public void SetAcademicDegree(string academicDegree)
        {
            if (AcademicDegree == academicDegree)
            {
                return;
            }

            AcademicDegree = academicDegree;
        }

        /// <summary>
        /// Задать научное звание
        /// </summary>
        /// <param name="academicRank">Научное звание</param>
        public void SetAcademicRank(string academicRank)
        {
            if (AcademicRank == academicRank)
            {
                return;
            }

            AcademicRank = academicRank;
        }

        /// <summary>
        /// Задать образование
        /// </summary>
        /// <param name="workPlace">Образование</param>
        public void SetEducation(string education)
        {
            if (Education == education)
            {
                return;
            }

            Education = education;
        }

        /// <summary>
        /// Задать место работы
        /// </summary>
        /// <param name="workPlace">Место работы</param>
        public void SetWorkPlace(string workPlace)
        {
            if (WorkPlace == workPlace)
            {
                return;
            }

            WorkPlace = workPlace;
        }

        /// <summary>
        /// Задать должность
        /// </summary>
        /// <param name="position">Должность</param>
        public void SetPosition(string position)
        {
            if (Position == position)
            {
                return;
            }

            Position = position;
        }

        /// <summary>
        /// Обновить сотрудника
        /// </summary>
        /// <param name="workPlace">Место работы сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        public void Update(
            string academicDegree,
            string academicRank,
            string education,
            string workPlace,
            string position)
        {
            SetAcademicDegree(academicDegree);
            SetAcademicRank(academicRank);
            SetEducation(education);
            SetWorkPlace(workPlace);
            SetPosition(position);
        }
    }
}