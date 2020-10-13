using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.WebApplication.Commands.Read.Contracts
{
    public interface IReadCommand<TDto> where TDto : class
    {
        Task<TDto> ExecuteAsync(Guid id);

        Task<IEnumerable<TDto>> ExecuteAsync();
    }
}