using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization
    {
        protected Organization()
        {
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Идентификатор государственной регистрации
        /// </summary>
        public virtual Guid StateRegistrationId { get; protected set; }

        /// <summary>
        /// Полное наименование
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Краткое наименование
        /// </summary>
        public virtual string ShortName { get; protected set; }

        /// <summary>
        /// Юридический адрес
        /// </summary>
        public virtual string LegalAddress { get; protected set; }

        /// <summary>
        /// Направление научной деятельности
        /// </summary>
        public virtual string ScientificActivity { get; protected set; }

        /// <summary>
        /// Инициализировать организацию
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="stateRegistrationId">Государственная регистрация</param>
        /// <param name="name">Наименование</param>
        /// <param name="shortName">Короткое наименование</param>
        /// <param name="scientificActivity">Научная деятельность</param>
        /// <param name="legalAddress">Юридический адрес</param>
        internal void Initialize(
            Guid id,
            Guid stateRegistrationId,
            string name,
            string shortName,
            string scientificActivity,
            string legalAddress)
        {
            /*Contract.Argument.IsValidIf(Id != id, $"{Id} (current) != {id} (new)");
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotEmptyGuid(stateRegistrationId, nameof(stateRegistrationId));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(name, nameof(name));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(shortName, nameof(shortName));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(scientificActivity, nameof(scientificActivity));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(legalAddress, nameof(legalAddress));*/

            Id = id;

            SetStateRegistrationId(stateRegistrationId);
            SetName(name);
            SetShortName(shortName);
            SetScientificActivity(scientificActivity);
            SetLegalAddress(legalAddress);
        }

        /// <summary>
        /// Задать государственную регистрацию
        /// </summary>
        /// <param name="stateRegistrationId">Государственная регистрация</param>
        public void SetStateRegistrationId(Guid stateRegistrationId)
        {
            //Contract.Argument.IsNotEmptyGuid(stateRegistrationId, nameof(stateRegistrationId));

            if (StateRegistrationId == stateRegistrationId)
            {
                return;
            }

            StateRegistrationId = stateRegistrationId;
        }

        /// <summary>
        /// Задать юридический адрес
        /// </summary>
        /// <param name="legalAddress">Юридический адрес</param>
        public void SetLegalAddress(string legalAddress)
        {
            /*Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(legalAddress, nameof(legalAddress));*/

            if (LegalAddress == legalAddress)
            {
                return;
            }

            LegalAddress = legalAddress;
        }

        /// <summary>
        /// Задать научную направленность
        /// </summary>
        /// <param name="scientificActivity">Научное направление</param>
        public void SetScientificActivity(string scientificActivity)
        {
            /*Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(scientificActivity, nameof(scientificActivity));*/

            if (ScientificActivity == scientificActivity)
            {
                return;
            }

            ScientificActivity = scientificActivity;
        }

        /// <summary>
        /// Задать короткое наименование
        /// </summary>
        /// <param name="shortName">Короткое наименование</param>
        public void SetShortName(string shortName)
        {
            /*Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(shortName, nameof(shortName));*/

            if (ShortName == shortName)
            {
                return;
            }

            ShortName = shortName;
        }

        /// <summary>
        /// Задать наименование
        /// </summary>
        /// <param name="name">Наименование</param>
        public void SetName(string name)
        {
            /*Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(name, nameof(name));*/

            if (Name == name)
            {
                return;
            }

            Name = name;
        }

        /// <summary>
        /// Обновить все данные по организации
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="shortName">Короткое наименование</param>
        /// <param name="scientificActivity">Научная деятельность</param>
        /// <param name="legalAddress">Юридический адрес</param>
        public void Update(
            string name,
            string shortName,
            string scientificActivity,
            string legalAddress)
        {
            /*
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(name, nameof(name));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(shortName, nameof(shortName));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(scientificActivity, nameof(scientificActivity));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(legalAddress, nameof(legalAddress));
            */

            SetName(name);
            SetShortName(shortName);
            SetScientificActivity(scientificActivity);
            SetLegalAddress(LegalAddress);
        }
    }
}