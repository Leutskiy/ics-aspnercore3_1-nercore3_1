using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Entities.System;
using ICS.Domain.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly SystemContext _systemContext;
        private readonly DomainContext _domainContext;

        public UserRepository(
            IIdGenerator idGenerator,
            SystemContext systemContext,
            DomainContext domainContext)
        {
            _idGenerator = idGenerator;
            _systemContext = systemContext;
            _domainContext = domainContext;
        }

        public User Create(string userName, string password, Profile profile = null)
        {
            var createdUser = _systemContext.Set<User>().CreateProxy();

            var id = _idGenerator.Generate();
            createdUser.Initialize(
                id: id,
                account: userName,
                password: password,
                profile: profile);

            var newUser = _systemContext.Set<User>().Add(createdUser);

            return newUser.Entity;
        }

        public async Task<User> Get(string userName, string password)
        {
            var user = await _systemContext.Set<User>().FirstOrDefaultAsync(ctx => ctx.AccountName == userName && ctx.Password == password);

            /*проверка на NULL*/

            return user;
        }

        public async Task<Guid> GetEmployeeId(Guid userId)
        {
            var employeeId = await _domainContext.Set<Employee>()
                    .Where(empl => empl.UserId == userId)
                    .Select(empl => empl.Id)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);

            if (employeeId == Guid.Empty)
            {
                throw new Exception($"Сотрудник не найден для пользователя с id: {userId}");
            }

            return employeeId;
        }

        public async Task<Guid> GetProfileId(Guid userId)
        {
            var profileId = await _systemContext.Set<Profile>()
                    .Where(prof => prof.UserId == userId)
                    .Select(prof => prof.Id)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);

            if (profileId == Guid.Empty)
            {
                throw new Exception($"Профиль не найден для пользователя с id: {userId}");
            }

            return profileId;
        }
    }
}
