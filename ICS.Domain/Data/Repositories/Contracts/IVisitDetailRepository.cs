using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Models;

namespace ICS.Domain.Data.Repositories
{
    public interface IVisitDetailRepository
    {
        Task<Guid> UpdateAsync(Guid visitDetailId, VisitDetailDto visitDetailDto);

        VisitDetail Create();

        VisitDetail Add(VisitDetailDto addedVisitDetail);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<VisitDetail>> GetAllAsync();

        Task<VisitDetail> GetAsync(Guid id);
    }
}