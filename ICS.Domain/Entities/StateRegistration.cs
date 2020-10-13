using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Государственная регистрация
    /// </summary>
    public class StateRegistration
    {
        protected StateRegistration()
        {

        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public virtual string Inn { get; protected set; }

        /// <summary>
        /// ОГРНИП
        /// </summary>
        public virtual string Ogrnip { get; protected set; }

        /// <summary>
        /// Инициализировать государственные регистрации
        /// </summary>
        internal void Initialize(
            Guid id,
            string inn,
            string ogrnip)
        {
            /*
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsValidIf(Id != id, $"{Id} (current) != {id} (new)");
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(inn, nameof(inn));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(ogrnip, nameof(ogrnip));
            */

            Id = id;

            SetInn(inn);
            SetOgrnip(ogrnip);
        }

        /// <summary>
        /// Задать ИНН
        /// </summary>
        /// <param name="inn">ИНН</param>
        public void SetInn(string inn)
        {
            /*Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(inn, nameof(inn));*/

            if (Inn == inn)
            {
                return;
            }

            Inn = inn;
        }

        /// <summary>
        /// Задать ОГРНИП
        /// </summary>
        /// <param name="ogrnip">ОГРНИП</param>
        public void SetOgrnip(string ogrnip)
        {
            /*Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(ogrnip, nameof(ogrnip));*/

            if (Ogrnip == ogrnip)
            {
                return;
            }

            Ogrnip = ogrnip;
        }

        /// <summary>
        /// Обновить государственную регистрацию
        /// </summary>
        public void Update(
            string inn,
            string ogrnip)
        {
            /*
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(inn, nameof(inn));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(ogrnip, nameof(ogrnip));
            */

            SetInn(inn);
            SetOgrnip(ogrnip);
        }
    }
}