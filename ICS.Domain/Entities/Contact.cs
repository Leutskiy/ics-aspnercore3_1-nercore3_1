using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Контакт
    /// </summary>
    public class Contact
    {
        protected Contact()
        {
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public virtual string Email { get; protected set; }

        /// <summary>
        /// Индекс
        /// </summary>
        public virtual string Postcode { get; protected set; }

        /// <summary>
        /// Домашний номер телефона
        /// </summary>
        public virtual string HomePhoneNumber { get; protected set; }

        /// <summary>
        /// Рабочий номер телефона
        /// </summary>
        public virtual string WorkPhoneNumber { get; protected set; }

        /// <summary>
        /// Мобильный номер телефона
        /// </summary>
        public virtual string MobilePhoneNumber { get; protected set; }

        /// <summary>
        /// Инициализировать контактные данные
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="postcode">Почтовый индекс</param>
        /// <param name="homePhoneNumber">Домашний номер телефона</param>
        /// <param name="workPhoneNumber">Рабочий номер телефона</param>
        /// <param name="mobilePhoneNumber">Мобильный номер телефона</param>
        internal void Initialize(
            Guid id,
            string email,
            string postcode,
            string homePhoneNumber,
            string workPhoneNumber,
            string mobilePhoneNumber)
        {
            /*
            Contract.Argument.IsValidIf(Id != id, $"{Id} (current) != {id} (new)");
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(email, nameof(email));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(postcode, nameof(postcode));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(homePhoneNumber, nameof(homePhoneNumber));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workPhoneNumber, nameof(workPhoneNumber));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(mobilePhoneNumber, nameof(mobilePhoneNumber));
            */

            Id = id;

            SetEmail(email);
            SetPostcode(postcode);
            SetHomePhoneNumber(homePhoneNumber);
            SetWorkPhoneNumber(workPhoneNumber);
            SetMobilePhoneNumber(mobilePhoneNumber);
        }

        /// <summary>
        /// Задать электронную почту
        /// </summary>
        /// <param name="email">Электронная почта</param>
        public void SetEmail(string email)
        {
            /*Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(email, nameof(email));*/

            if (Email == email)
            {
                return;
            }

            Email = email;
        }

        /// <summary>
        /// Задать почтовый индекс
        /// </summary>
        /// <param name="postcode">Почтовый индекс</param>
        public void SetPostcode(string postcode)
        {
            /*Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(postcode, nameof(postcode));*/

            if (Postcode == postcode)
            {
                return;
            }

            Postcode = postcode;
        }

        /// <summary>
        /// Задать рабочий номер телефона
        /// </summary>
        /// <param name="workPhoneNumber">Рабочий номер телефона</param>
        public void SetWorkPhoneNumber(string workPhoneNumber)
        {
            /*Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workPhoneNumber, nameof(workPhoneNumber));*/

            if (WorkPhoneNumber == workPhoneNumber)
            {
                return;
            }

            WorkPhoneNumber = workPhoneNumber;
        }

        /// <summary>
        /// Задать домашний телефонный номер
        /// </summary>
        /// <param name="homePhoneNumber">Домашний телефонный номер</param>
        public void SetHomePhoneNumber(string homePhoneNumber)
        {
            /*Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(homePhoneNumber, nameof(homePhoneNumber));*/

            if (HomePhoneNumber == homePhoneNumber)
            {
                return;
            }

            HomePhoneNumber = homePhoneNumber;
        }

        /// <summary>
        /// Задать мобильный номер телефона
        /// </summary>
        /// <param name="mobilePhoneNumber">Мобильный номер телефона</param>
        public void SetMobilePhoneNumber(string mobilePhoneNumber)
        {
            /*Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(mobilePhoneNumber, nameof(mobilePhoneNumber));*/

            if (MobilePhoneNumber == mobilePhoneNumber)
            {
                return;
            }

            MobilePhoneNumber = mobilePhoneNumber;
        }

        /// <summary>
        /// Полностью обновить контакт
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <param name="postcode">Почтовый индекс</param>
        /// <param name="homePhoneNumber">Домашний номер телефона</param>
        /// <param name="workPhoneNumber">Рабочий номер телефона</param>
        /// <param name="mobilePhoneNumber">Мобильный номер телефона</param>
        public void Update(
            string email,
            string postcode,
            string homePhoneNumber,
            string workPhoneNumber,
            string mobilePhoneNumber)
        {
            /*
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(email, nameof(email));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(postcode, nameof(postcode));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(homePhoneNumber, nameof(homePhoneNumber));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workPhoneNumber, nameof(workPhoneNumber));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(mobilePhoneNumber, nameof(mobilePhoneNumber));
            */

            SetEmail(email);
            SetPostcode(postcode);
            SetHomePhoneNumber(homePhoneNumber);
            SetWorkPhoneNumber(workPhoneNumber);
            SetMobilePhoneNumber(mobilePhoneNumber);
        }
    }
}