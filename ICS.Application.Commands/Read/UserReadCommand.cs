using ICS.Domain.Data.Repositories.Contracts;
using ICS.Shared;
using System;
using System.Threading.Tasks;

namespace ICS.WebApplication.Commands.Read
{
    /// <summary>
    /// Команда для чтения пользовательских данных
    /// </summary>
    public sealed class UserReadCommand
    {
        private readonly IUserRepository _userRepository;

        public UserReadCommand(
            IUserRepository userRepository)
        {
            Contract.Argument.IsNotNull(userRepository, nameof(userRepository));

            _userRepository = userRepository;
        }

        /// <summary>
        /// Получить идентификатор сотрудника
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Идентификатор сотрудника</returns>
        public async Task<Guid> GetEmployeeIdAsync(Guid userId)
        {
            Contract.Argument.IsNotEmptyGuid(userId, nameof(userId));

            return await _userRepository.GetEmployeeId(userId).ConfigureAwait(false);
        }
    }
}
