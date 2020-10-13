using ICS.Domain.Data.Repositories;
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
    /// Команда чтения деталей визита
    /// </summary>
    public sealed class VisitDetailReadCommand : IReadCommand<VisitDetailResult>
    {
        private readonly IVisitDetailRepository _visitDetailRepository;

        public VisitDetailReadCommand(IVisitDetailRepository visitDetailRepository)
        {
            Contract.Argument.IsNotNull(visitDetailRepository, nameof(visitDetailRepository));

            _visitDetailRepository = visitDetailRepository;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="visitDetailId">Идентификатор деталей визита</param>
        /// <returns>Информация о деталях визита</returns>
        public async Task<VisitDetailResult> ExecuteAsync(Guid visitDetailId)
        {
            Contract.Argument.IsNotEmptyGuid(visitDetailId, nameof(visitDetailId));

            var visitDetail = await _visitDetailRepository.GetAsync(visitDetailId).ConfigureAwait(false);

            return DomainEntityConverter.ConvertToResult(visitDetail: visitDetail);
        }

        public Task<IEnumerable<VisitDetailResult>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}