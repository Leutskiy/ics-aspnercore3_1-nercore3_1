using ICS.Domain.Data.Adapters;
using ICS.Domain.Entities;
using ICS.Domain.Enums;
using ICS.Domain.Repositories.Contracts;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.Domain.Repositories
{
    /// <summary>
    /// Репозиторий документов
    /// </summary>
    public sealed class DocumentRepository : IDocumentRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainContext _context;

        public DocumentRepository(
            IIdGenerator idGenerator,
            DomainContext databaseContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        /// <summary>
        /// Получить все документы
        /// </summary>
        /// <returns>Документы</returns>
        public async Task<IEnumerable<Document>> GetAllAsync()
        {
            var documents = await _context.Set<Document>().ToArrayAsync().ConfigureAwait(false);

            return documents;
        }

        /// <summary>
        /// Получить документ по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns>Документ</returns>
        public async Task<Document> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var document = await _context.Set<Document>().FindAsync(id).ConfigureAwait(false);

            if (document == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return document;
        }

        /// <summary>
        /// Создать документ
        /// </summary>
        /// <param name="invitationId">Идентификатор приглашения</param>
        /// <param name="name">Название</param>
        /// <param name="content">Содержимое</param>
        /// <param name="createdDate">Дата создания</param>
        /// <param name="updateDate">Дата изменения</param>
        /// <param name="documentType">Тип документа</param>
        /// <returns>Идентификатор документа</returns>
        public Guid Create(
            Guid invitationId,
            string name,
            byte[] content,
            DateTime createdDate,
            DateTime updateDate,
            DocumentType documentType)
        {
            Contract.Argument.IsNotEmptyGuid(invitationId, nameof(invitationId));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(name, nameof(name));
            Contract.Argument.IsNotNull(content, nameof(content));
            Contract.Argument.IsValidIf(createdDate <= updateDate, $"{nameof(createdDate)}:{createdDate} < {nameof(updateDate)}:{updateDate}");

            var createdDocument = _context.Set<Document>().CreateProxy();
            var id = _idGenerator.Generate();
            createdDocument.Initialize(
                id: id,
                invitationId: invitationId,
                name: name,
                content: content,
                createdDate: createdDate,
                updateDate: updateDate,
                documentType: documentType);

            var newDocument = _context.Set<Document>().Add(createdDocument);

            return newDocument.Entity.Id;
        }

        /// <summary>
        /// Удалить документ
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id));
            }

            var deletedDocument = await _context.Set<Document>()
                .FirstOrDefaultAsync(documentItem => documentItem.Id == id).ConfigureAwait(false);

            if (deletedDocument == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            _context.Set<Document>().Remove(deletedDocument);
        }
    }
}