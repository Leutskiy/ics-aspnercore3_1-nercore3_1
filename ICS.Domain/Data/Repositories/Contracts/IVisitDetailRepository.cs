using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;

namespace ICS.Domain.Data.Repositories
{
    public interface IVisitDetailRepository
    {
        VisitDetail Create(
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
            VisaMultiplicity visaMultiplicity);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<VisitDetail>> GetAllAsync();

        Task<VisitDetail> GetAsync(Guid id);
    }
}