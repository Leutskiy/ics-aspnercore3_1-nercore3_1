using ICS.Domain.Data.Adapters;
using ICS.Domain.Entities;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories
{
    /// <summary>
    /// Репозиторий деталей поездки
    /// </summary>
    public sealed class VisitDetailRepository : IVisitDetailRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainContext _context;

        public VisitDetailRepository(
            IIdGenerator idGenerator,
            DomainContext databaseContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        /// <summary>
        /// Получить все детали визита
        /// </summary>
        /// <returns>Детали визита</returns>
        public async Task<IEnumerable<VisitDetail>> GetAllAsync()
        {
            var visitDetails = await _context.Set<VisitDetail>().ToArrayAsync().ConfigureAwait(false);

            return visitDetails;
        }

        /// <summary>
        /// Получить детали визита по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор деталей визита</param>
        /// <returns>Детали визита</returns>
        public async Task<VisitDetail> GetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id));
            }

            var visitDetail = await _context.Set<VisitDetail>().FindAsync(id).ConfigureAwait(false);

            if (visitDetail == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return visitDetail;
        }

        /// <summary>
        /// Создать детали визита
        /// </summary>
        /// <param name="goal">Цель визита</param>
        /// <param name="country">Страна визита</param>
        /// <param name="visitingPoints">Пункты посещения</param>
        /// <param name="period">Период пребывания</param>
        /// <param name="arrivalDate">Дата прибытия</param>
        /// <param name="departureDate">Дата отъезда</param>
        /// <param name="visaType">Тип визы</param>
        /// <param name="visaCity">Город получения визы</param>
        /// <param name="visaCountry">Страна получения визы</param>
        /// <param name="visaMultiplicity">Кратность визы</param>
        /// <returns>Идентификатор деталей визита</returns>
        public VisitDetail Create(
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
            /*
            Contract.Argument.IsNotEmptyGuid(invitationId, nameof(invitationId));
            Contract.Argument.IsValidIf(periodDays > 0, $"{nameof(periodDays)} > 0");
            Contract.Argument.IsValidIf(arrivalDate < departureDate, $"{nameof(arrivalDate)}:{arrivalDate} < {nameof(departureDate)}:{departureDate}");
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(goal, nameof(goal));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(country, nameof(country));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visitingPoints, nameof(visitingPoints));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaType, nameof(visaType));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaCity, nameof(visaCity));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaCountry, nameof(visaCountry));
            */

            var createdVisitDetail = _context.Set<VisitDetail>().CreateProxy();

            var id = _idGenerator.Generate();
                createdVisitDetail.Initialize(
                    id: id,
                    invitationId: invitationId,
                    goal: goal,
                    country: country,
                    visitingPoints: visitingPoints,
                    periodDays: periodDays,
                    arrivalDate: arrivalDate,
                    departureDate: departureDate,
                    visaType: visaType,
                    visaCity: visaCity,
                    visaCountry: visaCountry,
                    visaMultiplicity: visaMultiplicity);

            var newVisitDetail = _context.Set<VisitDetail>().Add(createdVisitDetail);

            return newVisitDetail.Entity;
        }

        /// <summary>
        /// Удалить детали визита
        /// </summary>
        /// <param name="id">Идентификатор детелей визита</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var deletedVisitDetail = await GetAsync(id).ConfigureAwait(false);

            _context.Set<VisitDetail>().Remove(deletedVisitDetail);
        }
    }
}