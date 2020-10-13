using ICS.Domain.Enums;
using System;
using System.Linq;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Документ
    /// </summary>
    public class Document
    {
        protected Document()
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
        /// Наименование
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Содержимое
        /// </summary>
        public virtual byte[] Content { get; protected set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public virtual DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public virtual DateTime UpdateDate { get; protected set; }

        /// <summary>
        /// Тип документа
        /// </summary>
        public virtual DocumentType DocumentType { get; protected set; }

        /// <summary>
        /// Инициализировать документ
        /// </summary>
        internal void Initialize(
            Guid id,
            Guid invitationId,
            string name,
            byte[] content,
            DateTime createdDate,
            DateTime updateDate,
            DocumentType documentType)
        {
            /*Contract.Argument.IsValidIf(Id != id, $"{Id} (current) != {id} (new)");
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsValidIf(createdDate <= updateDate, $"{nameof(createdDate)}:{createdDate} < {nameof(updateDate)}:{updateDate}");
            Contract.Argument.IsNotEmptyGuid(invitationId, nameof(invitationId));
            Contract.Argument.IsNotNull(content, nameof(content));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(name, nameof(name));*/

            Id = id;

            SetInvitationId(invitationId);
            SetName(name);
            SetContent(content);
            SetCreatedDate(createdDate);
            SetUpdateDate(updateDate);
            SetDocumentType(documentType);
        }

        /// <summary>
        /// Задатьт идентификатор приглашения
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
        /// Задать название
        /// </summary>
        /// <param name="name">Название</param>
        internal void SetName(string name)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(name, nameof(name));

            if (Name == name)
            {
                return;
            }

            Name = name;
        }

        /// <summary>
        /// Задать контент
        /// </summary>
        /// <param name="content">Контент</param>
        internal void SetContent(byte[] content)
        {
            //Contract.Argument.IsNotNull(content, nameof(content));

            if (Content.SequenceEqual(content))
            {
                return;
            }

            Content = content;
        }

        /// <summary>
        /// Задать дату создания
        /// </summary>
        /// <param name="createdDate">Дата создания</param>
        internal void SetCreatedDate(DateTime createdDate)
        {
            if (CreatedDate == createdDate)
            {
                return;
            }

            CreatedDate = createdDate;
        }

        /// <summary>
        /// Задать дату обновления
        /// </summary>
        /// <param name="updateDate">Дата обновления</param>
        internal void SetUpdateDate(DateTime updateDate)
        {
            if (UpdateDate == updateDate)
            {
                return;
            }

            UpdateDate = updateDate;
        }

        /// <summary>
        /// Задать тип документа
        /// </summary>
        /// <param name="documentType">Тип документа</param>
        internal void SetDocumentType(DocumentType documentType)
        {
            if (DocumentType == documentType)
            {
                return;
            }

            DocumentType = documentType;
        }
    }
}