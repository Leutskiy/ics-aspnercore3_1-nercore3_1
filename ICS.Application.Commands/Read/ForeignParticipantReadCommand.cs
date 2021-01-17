using ICS.Domain.Data.Repositories.Contracts;
using ICS.Shared;
using ICS.WebApplication.Commands.Converters;
using ICS.WebApplication.Commands.Read.Contracts;
using ICS.WebApplication.Commands.Read.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.WebApplication.Commands.Read
{
    /// <summary>
    /// Команда чтения иностранных участников
    /// </summary>
    public sealed class ForeignParticipantReadCommand : IReadCommand<ForeignParticipantResult>
    {
        private readonly IForeignParticipantRepository _foreignParticipantRepository;

        public ForeignParticipantReadCommand(
            IForeignParticipantRepository foreignParticipantRepository)
        {
            Contract.Argument.IsNotNull(foreignParticipantRepository, nameof(foreignParticipantRepository));

            _foreignParticipantRepository = foreignParticipantRepository;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="foreignParticipantIds">Идентификаторы иностранных участников</param>
        /// <returns>Информация об иностранных участниках</returns>
        public async Task<IEnumerable<ForeignParticipantResult>> ExecuteAsync(IEnumerable<Guid> foreignParticipantIds)
        {
            Contract.Argument.IsNotNull(foreignParticipantIds, nameof(foreignParticipantIds));

            var foreignParticipantDtos = new List<ForeignParticipantResult>();
            foreach (var foreignParticipantId in foreignParticipantIds)
            {
                var foreignParticipantDto = await ExecuteAsync(foreignParticipantId);

                foreignParticipantDtos.Add(foreignParticipantDto);
            }

            return foreignParticipantDtos;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="foreignParticipantId">Идентификатор иностранного участника</param>
        /// <returns>Информация об иностранном участнике</returns>
        public async Task<ForeignParticipantResult> ExecuteAsync(Guid foreignParticipantId)
        {
            Contract.Argument.IsNotEmptyGuid(foreignParticipantId, nameof(foreignParticipantId));

            var foreignParticipant = await _foreignParticipantRepository.GetAsync(foreignParticipantId);

            return DomainEntityConverter.ConvertToResult(foreignParticipant: foreignParticipant);
        }

        public Task<IEnumerable<ForeignParticipantResult>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}