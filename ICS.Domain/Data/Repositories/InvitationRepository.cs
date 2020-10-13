using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Enums;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories
{
    /// <summary>
    /// Репозиторий приглашений
    /// </summary>
    public sealed class InvitationRepository : IInvitationRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainContext _context;

        public InvitationRepository(
            IIdGenerator idGenerator,
            DomainContext databaseContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        /// <summary>
        /// Получить все приглашения
        /// </summary>
        /// <returns>Приглашения</returns>
        public async Task<IEnumerable<Invitation>> GetAllAsync()
        {
            var invitations = await _context.Set<Invitation>().ToArrayAsync().ConfigureAwait(false);

            return invitations;
        }

        /// <summary>
        /// Получить приглашение по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор приглашения</param>
        /// <returns>Приглашение</returns>
        public async Task<Invitation> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var invitation = await _context.Set<Invitation>().FindAsync(id).ConfigureAwait(false);

            if (invitation == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return invitation;
        }

        /// <summary>
        ///  Создать приглашение
        /// </summary>
        /// <param name="alienId">Иностранец</param>
        /// <param name="employeeId">Сотрудник</param>
        /// <param name="visitDetailId">Детали визита</param>
        /// <param name="foreignParticipants">Сопровождение</param>
        /// <param name="createdDate">Дата создания</param>
        /// <param name="updateDate">Дата изменения</param>
        /// <param name="invitationStatus">Статус приглашения</param>
        /// <returns>Идентификатор приглашения</returns>
        public Invitation Create(
            Guid alienId,
            Guid employeeId,
            Guid visitDetailId,
            ICollection<ForeignParticipant> foreignParticipants,
            DateTimeOffset createdDate,
            DateTimeOffset updateDate,
            InvitationStatus invitationStatus)
        {
            Contract.Argument.IsNotEmptyGuid(alienId, nameof(alienId));
            Contract.Argument.IsNotEmptyGuid(employeeId, nameof(employeeId));
            Contract.Argument.IsNotEmptyGuid(visitDetailId, nameof(visitDetailId));
            Contract.Argument.IsNotNull(foreignParticipants, nameof(foreignParticipants));
            Contract.Argument.IsValidIf(createdDate <= updateDate, $"{nameof(createdDate)}:{createdDate} < {nameof(updateDate)}:{updateDate}");

            var createdInvitation = _context.Set<Invitation>().CreateProxy();

            var id = _idGenerator.Generate();
            createdInvitation.Initialize(
                id: id,
                alienId: alienId, 
                employeeId: employeeId,
                visitDetailId: visitDetailId,
                foreignParticipants: foreignParticipants,
                createdDate: createdDate,
                updateDate: updateDate,
                invitationStatus: invitationStatus);

            var newInvitation = _context.Set<Invitation>().Add(createdInvitation);

            return newInvitation.Entity;
        }

        /// <summary>
        /// Удалить приглашение по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор приглашения</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var deletedInvitation = await GetAsync(id).ConfigureAwait(false);

            _context.Set<Invitation>().Remove(deletedInvitation);
        }
    }
}