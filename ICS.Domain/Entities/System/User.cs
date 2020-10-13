using System;

namespace ICS.Domain.Entities.System
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class User
    {
        protected User()
        {
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Идентификатор профиля
        /// </summary>
        public virtual Guid? ProfileId { get; protected set; }

        /// <summary>
        /// Имя аккаунта
        /// </summary>
        public virtual string AccountName { get; protected set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public virtual string Password { get; protected set; }

        /// <summary>
        /// Информация о профиле
        /// Профиль может быть не задан, если служебная учетка (например, админ)
        /// </summary>
        public virtual Profile Profile { get; protected set; }

        internal void Initialize(
           Guid id,
           string account,
           string password,
           Profile profile = null)
        {
            Id = id;
            SetAccount(account);
            SetPassword(password);
            SetProfile(profile);
        }

        public void SetAccount(string account)
        {
            if (AccountName == account)
            {
                return;
            }

            AccountName = account;
        }

        public void SetPassword(string password)
        {
            if (Password == password)
            {
                return;
            }

            Password = password;
        }

        public void SetProfile(Profile profile)
        {
            if (ProfileId == profile?.Id)
            {
                return;
            }

            ProfileId = profile.Id;
        }
    }
}