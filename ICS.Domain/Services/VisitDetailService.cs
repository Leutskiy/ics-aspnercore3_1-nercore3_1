using ICS.Domain.Data.Repositories;
using ICS.Domain.Entities;
using ICS.Domain.Models;
using ICS.Domain.Services.Contracts;
using ICS.Shared;

namespace ICS.Domain.Services
{
    /// <summary>
    /// Сервис для работы с деталями визита
    /// </summary>
    public sealed class VisitDetailService : IVisitDetailService
    {
        private readonly IVisitDetailRepository _visitDetailRepository;

        public VisitDetailService(
            IVisitDetailRepository visitDetailRepository)
        {
            Contract.Argument.IsNotNull(visitDetailRepository, nameof(visitDetailRepository));

            _visitDetailRepository = visitDetailRepository;
        }

        /// <summary>
        /// Добавить детали визита
        /// </summary>
        /// <param name="addedVisitDetail">DTO деталей визита</param>
        /// <returns>Детали визита</returns>
        public VisitDetail Add(VisitDetailDto addedVisitDetail)
        {
            Contract.Argument.IsNotNull(addedVisitDetail, nameof(addedVisitDetail));

            var visitDetail = _visitDetailRepository.Create(
                invitationId: addedVisitDetail.InvitationId,
                goal: addedVisitDetail.Goal,
                country: addedVisitDetail.Country,
                visitingPoints: addedVisitDetail.VisitingPoints,
                periodDays: addedVisitDetail.PeriodInDays,
                arrivalDate: addedVisitDetail.ArrivalDate,
                departureDate: addedVisitDetail.DepartureDate,
                visaType: addedVisitDetail.VisaType,
                visaCity: addedVisitDetail.VisaCity,
                visaCountry: addedVisitDetail.VisaCountry,
                visaMultiplicity: addedVisitDetail.VisaMultiplicity);

            return visitDetail;
        }
    }
}