using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Enums;

namespace ICS.Domain.Repositories.Contracts
{
    public interface IDocumentRepository
    {
        Guid Create(
            Guid invitationId,
            string name,
            byte[] content,
            DateTime createdDate,
            DateTime updateDate,
            DocumentType documentType);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<Document>> GetAllAsync();

        Task<Document> GetAsync(Guid id);
    }
}