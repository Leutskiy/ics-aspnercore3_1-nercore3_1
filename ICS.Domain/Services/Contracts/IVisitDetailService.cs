using ICS.Domain.Entities;
using ICS.Domain.Models;

namespace ICS.Domain.Services.Contracts
{
    public interface IVisitDetailService
    {
        VisitDetail Add(VisitDetailDto addedVisitDetail);
    }
}