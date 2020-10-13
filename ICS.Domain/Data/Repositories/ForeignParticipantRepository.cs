using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
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
    /// Репозиторий иностранных участников
    /// </summary>
    public sealed class ForeignParticipantRepository : IForeignParticipantRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainContext _context;

        public ForeignParticipantRepository(
            IIdGenerator idGenerator,
            DomainContext databaseContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        /// <summary>
        /// Получить всех иностранных участников
        /// </summary>
        /// <returns>Иностранные участники</returns>
        public async Task<IEnumerable<ForeignParticipant>> GetAllAsync()
        {
            var foreignParticipants = await _context.Set<ForeignParticipant>().ToArrayAsync().ConfigureAwait(false);

            return foreignParticipants;
        }

        /// <summary>
        /// Получить иностранного участника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор иностранного участника</param>
        /// <returns>Иностранный участник</returns>
        public async Task<ForeignParticipant> GetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id));
            }

            var foreignParticipant = await _context.Set<ForeignParticipant>().FindAsync(id).ConfigureAwait(false);

            if (foreignParticipant == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return foreignParticipant;
        }

        /// <summary>
        /// Создать иностранного участника
        /// </summary>
        /// <param name="alienId">Идентификатор иностранца</param>
        /// <param name="passportId">Паспорт</param>
        /// <returns>Идентификатор инстранного участника</returns>
        public ForeignParticipant Create(
            Guid alienId,
            Guid passportId,
            Guid invitationId)
        {
            Contract.Argument.IsNotEmptyGuid(alienId, nameof(alienId));
            Contract.Argument.IsNotEmptyGuid(passportId, nameof(passportId));
            Contract.Argument.IsNotEmptyGuid(invitationId, nameof(invitationId));

            var createdForeignParticipant = _context.Set<ForeignParticipant>().CreateProxy();

            var id = _idGenerator.Generate();
            createdForeignParticipant.Initialize(
                id: id,
                alienId: alienId,
                passportId: passportId,
                invitationId: invitationId);

            var newForeignParticipant = _context.Set<ForeignParticipant>().Add(createdForeignParticipant);

            return newForeignParticipant.Entity;
        }

        /// <summary>
        /// Удалить иностранного участника
        /// </summary>
        /// <param name="id">Идентификатор иностранного участника</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id));
            }

            var deletedForeignParticipant = await _context.Set<ForeignParticipant>()
                .FirstOrDefaultAsync(foreignParticipantItem => foreignParticipantItem.Id == id).ConfigureAwait(false);

            if (deletedForeignParticipant == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            _context.Set<ForeignParticipant>().Remove(deletedForeignParticipant);
        }
    }
}