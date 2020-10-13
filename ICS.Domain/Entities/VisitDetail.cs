using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Детали визита
    /// </summary>
    public class VisitDetail
    {
        protected VisitDetail()
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
        /// Цель визита
        /// </summary>
        public virtual string Goal { get; protected set; }

        /// <summary>
        /// Страна визита
        /// </summary>
        public virtual string Country { get; protected set; }

        /// <summary>
        /// Пункты посещения
        /// </summary>
        public virtual string VisitingPoints { get; protected set; }

        /// <summary>
        /// Период в днях
        /// </summary>
        public virtual long PeriodDays { get; protected set; }

        /// <summary>
        /// Период пребывания
        /// </summary>
        public TimeSpan Period => TimeSpan.FromDays(PeriodDays);

        /// <summary>
        /// Дата пребытия
        /// </summary>
        public virtual DateTime ArrivalDate  { get; protected set; }

        /// <summary>
        /// Дата депортации
        /// </summary>
        public virtual DateTime DepartureDate { get; protected set; }

        /// <summary>
        /// Вид визы
        /// </summary>
        public virtual string VisaType { get; protected set; }

        /// <summary>
        /// Город получения визы
        /// </summary>
        public virtual string VisaCity { get; protected set; }

        /// <summary>
        /// Страна получения визы
        /// </summary>
        public virtual string VisaCountry { get; protected set; }

        /// <summary>
        /// Кратность визы
        /// </summary>
        public virtual VisaMultiplicity VisaMultiplicity { get; protected set; }

        /// <summary>
        /// Инициализировать детали визита
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="invitationId">Идентификатор приглашения</param>
        /// <param name="goal">Цель визита</param>
        /// <param name="country">Страна визита</param>
        /// <param name="visitingPoints">Посещаемые пункты</param>
        /// <param name="period">Период пребывания</param>
        /// <param name="arrivalDate">Дата пребытия</param>
        /// <param name="departureDate">Дата депортации</param>
        /// <param name="visaType">Тип визы</param>
        /// <param name="visaCity">Город получения визы</param>
        /// <param name="visaCountry">Страна получения визы</param>
        /// <param name="visaMultiplicity">Кратность визы</param>
        internal void Initialize(
            Guid id,
            Guid invitationId,
            string goal,
            string country,
            string visitingPoints,
            long periodDays,
            DateTime arrivalDate,
            DateTime departureDate,
            string visaType,
            string visaCity,
            string visaCountry,
            VisaMultiplicity visaMultiplicity)
        {
            /*Contract.Argument.IsValidIf(Id != id, $"{Id} (current) != {id} (new)");
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotEmptyGuid(invitationId, nameof(invitationId));
            Contract.Argument.IsValidIf(periodDays > 0, $"{nameof(periodDays)} > 0");
            Contract.Argument.IsValidIf(arrivalDate < departureDate, $"{nameof(arrivalDate)}:{arrivalDate} < {nameof(departureDate)}:{departureDate}");
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(goal, nameof(goal));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(country, nameof(country));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visitingPoints, nameof(visitingPoints));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaType, nameof(visaType));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaCity, nameof(visaCity));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaCountry, nameof(visaCountry));*/

            Id = id;

            SetInvitationId(invitationId);
            SetGoal(goal);
            SetCountry(country);
            SetVisitingPoints(visitingPoints);
            SetArrivalDate(arrivalDate);
            SetDepartureDate(departureDate);
            SetPeriodDays(periodDays);
            SetVisaCountry(country);
            SetVisaCity(visaCity);
            SetVisaType(visaType);
            SetVisaMultiplicity(VisaMultiplicity);
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
        /// Задать цель визита
        /// </summary>
        /// <param name="goal">Цель визита</param>
        internal void SetGoal(string goal)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(goal, nameof(goal));

            if (Goal == goal)
            {
                return;
            }

            Goal = goal;
        }

        /// <summary>
        /// Задать страну визита
        /// </summary>
        /// <param name="country">Страна визита</param>
        internal void SetCountry(string country)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(country, nameof(country));

            if (Country == country)
            {
                return;
            }

            Country = country;
        }

        /// <summary>
        /// Задать пункты посещения
        /// </summary>
        /// <param name="visitingPoints">Пункты посещения</param>
        internal void SetVisitingPoints(string visitingPoints)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visitingPoints, nameof(visitingPoints));

            if (VisitingPoints == visitingPoints)
            {
                return;
            }

            VisitingPoints = visitingPoints;
        }

        /// <summary>
        /// Задать пункты посещения по отдельности
        /// </summary>
        /// <param name="visitingPoints">Перечисление пунктов посещения</param>
        internal void SetVisitingPoints(params string[] visitingPoints)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visitingPoints, nameof(visitingPoints));

            var concatedVisitingPoints = string.Join(", ", visitingPoints);

            if (VisitingPoints == concatedVisitingPoints)
            {
                return;
            }

            VisitingPoints = concatedVisitingPoints;
        }

        /// <summary>
        /// Задать период пребывания в днях
        /// </summary>
        /// <param name="period">Период пребывания в днях</param>
        internal void SetPeriodDays(long periodDays)
        {
            //Contract.Argument.IsValidIf(periodDays > 0, $"{nameof(periodDays)} > 0");

            if (PeriodDays == periodDays)
            {
                return;
            }

            PeriodDays = periodDays;
        }

        /// <summary>
        /// Задать дату пребытия
        /// </summary>
        /// <param name="arrivalDate">Дата пребытия</param>
        internal void SetArrivalDate(DateTime arrivalDate)
        {
            if (ArrivalDate == arrivalDate)
            {
                return;
            }

            ArrivalDate = arrivalDate;
        }

        /// <summary>
        /// Задать дату депортации
        /// </summary>
        /// <param name="departureDate">Дата депортации</param>
        internal void SetDepartureDate(DateTime departureDate)
        {
            if (DepartureDate == departureDate)
            {
                return;
            }

            DepartureDate = departureDate;
        }

        /// <summary>
        /// Задать тип визы
        /// </summary>
        /// <param name="visaType">Тип визы</param>
        internal void SetVisaType(string visaType)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaType, nameof(visaType));

            if (VisaType == visaType)
            {
                return;
            }

            VisaType = visaType;
        }

        /// <summary>
        /// Задать город получения визы
        /// </summary>
        /// <param name="visaCity">Город получения визы</param>
        internal void SetVisaCity(string visaCity)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaCity, nameof(visaCity));

            if (VisaCity == visaCity)
            {
                return;
            }

            VisaCity = visaCity;
        }

        /// <summary>
        /// Задать страну получения визы
        /// </summary>
        /// <param name="visaCountry">Страна получения визы</param>
        internal void SetVisaCountry(string visaCountry)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaCountry, nameof(visaCountry));

            if (VisaCountry == visaCountry)
            {
                return;
            }

            VisaCountry = visaCountry;
        }

        /// <summary>
        /// Задать кратность визы
        /// </summary>
        /// <param name="visaMultiplicity">Кратность визы</param>
        internal void SetVisaMultiplicity(VisaMultiplicity visaMultiplicity)
        {
            if (VisaMultiplicity == visaMultiplicity)
            {
                return;
            }

            VisaMultiplicity = visaMultiplicity;
        }
    }
}