using ICS.Shared;
using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Иностранец
    /// </summary>
    public class Alien
    {
        protected Alien()
        {
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Идентификатор приглашения
        /// </summary>
        public virtual Guid InvitationId { get; protected set; }

        /// <summary>
        /// Идентификатор контактных данных
        /// </summary>
        public virtual Guid ContactId { get; protected set; }

        /// <summary>
        /// Идентификатор паспортных данных
        /// </summary>
        public virtual Guid PassportId { get; protected set; }

        /// <summary>
        /// Идентификатор организации
        /// </summary>
        public virtual Guid OrganizationId { get; protected set; }

        /// <summary>
        /// Идентификатор государственной регистрации
        /// </summary>
        public virtual Guid StateRegistrationId { get; protected set; }

        /// <summary>
        /// Должность
        /// </summary>
        public virtual string Position { get; protected set; }

        /// <summary>
        /// Место работы
        /// </summary>
        public virtual string WorkPlace { get; protected set; }

        /// <summary>
        /// Адрес работы
        /// </summary>
        public virtual string WorkAddress { get; protected set; }

        /// <summary>
        /// Адрес пребывания
        /// </summary>
        public virtual string StayAddress { get; protected set; }

        /// <summary>
        /// Инициализировать иностранца
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="invitationId">Идентификатор приглашения</param>
        /// <param name="contactId">Контакт</param>
        /// <param name="passportId">Паспорт</param>
        /// <param name="organizationId">Организация</param>
        /// <param name="stateRegistrationId">Государственная регистрация</param>
        /// <param name="position">Должность</param>
        /// <param name="workPlace">Место работы</param>
        /// <param name="workAddress">Адрес места работы</param>
        /// <param name="stayAddress">Адрес пребывания</param>
        internal void Initialize(
            Guid id,
            Guid invitationId,
            Guid contactId,
            Guid passportId,
            Guid organizationId,
            Guid stateRegistrationId,
            string position,
            string workPlace,
            string workAddress,
            string stayAddress)
        {
            Contract.Argument.IsValidIf(Id != id, $"{Id} (current) != {id} (new)");
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotEmptyGuid(invitationId, nameof(invitationId));
            Contract.Argument.IsNotEmptyGuid(contactId, nameof(contactId));
            Contract.Argument.IsNotEmptyGuid(passportId, nameof(passportId));
            Contract.Argument.IsNotEmptyGuid(organizationId, nameof(organizationId));
            Contract.Argument.IsNotEmptyGuid(stateRegistrationId, nameof(stateRegistrationId));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(position, nameof(position));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workPlace, nameof(workPlace));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workAddress, nameof(workAddress));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(stayAddress, nameof(stayAddress));

            Id = id;

            SetInvitationId(invitationId);
            SetContactId(contactId);
            SetPassportId(passportId);
            SetOrganizationId(organizationId);
            SetStateRegistrationId(stateRegistrationId);
            SetPosition(position);
            SetWorkPlace(workPlace);
            SetWorkAddress(workAddress);
            SetStayAddress(stayAddress);
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
        /// Задать должность
        /// </summary>
        /// <param name="position">Должность</param>
        internal void SetPosition(string position)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(position, nameof(position));

            if (Position == position)
            {
                return;
            }

            Position = position;
        }

        /// <summary>
        /// Задать место работы
        /// </summary>
        /// <param name="workPlace">Место работы</param>
        internal void SetWorkPlace(string workPlace)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workPlace, nameof(workPlace));

            if (WorkPlace == workPlace)
            {
                return;
            }

            WorkPlace = workPlace;
        }

        /// <summary>
        /// Адрес работы
        /// </summary>
        /// <param name="workAddress">Рабочий адрес</param>
        internal void SetWorkAddress(string workAddress)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workAddress, nameof(workAddress));

            if (WorkAddress == workAddress)
            {
                return;
            }

            WorkAddress = workAddress;
        }

        /// <summary>
        /// Задать адрес пребывания
        /// </summary>
        /// <param name="stayAddress">Адрес пребывания</param>
        internal void SetStayAddress(string stayAddress)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(stayAddress, nameof(stayAddress));

            if (StayAddress == stayAddress)
            {
                return;
            }

            StayAddress = stayAddress;
        }

        /// <summary>
        /// Задать контактные данные
        /// </summary>
        /// <param name="contactId">Контактые данные</param>
        internal void SetContactId(Guid contactId)
        {
            //Contract.Argument.IsNotEmptyGuid(contactId, nameof(contactId));

            if (ContactId == contactId)
            {
                return;
            }

            ContactId = contactId;
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

        /// <summary>
        /// Задать организацию
        /// </summary>
        /// <param name="organizationId">Организация</param>
        internal void SetOrganizationId(Guid organizationId)
        {
            //Contract.Argument.IsNotEmptyGuid(organizationId, nameof(organizationId));

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
        internal void SetStateRegistrationId(Guid stateRegistrationId)
        {
            //Contract.Argument.IsNotEmptyGuid(stateRegistrationId, nameof(stateRegistrationId));

            if (StateRegistrationId == stateRegistrationId)
            {
                return;
            }

            StateRegistrationId = stateRegistrationId;
        }
    }
}