using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities.System;
using ICS.Domain.Models;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly SystemContext _systemContext;

        public ProfileRepository(
            IIdGenerator idGenerator,
            SystemContext systemContext)
        {
            _idGenerator = idGenerator;
            _systemContext = systemContext;
        }

        public async Task<Profile> CreateAsync(User user)
        {
            var createdProfile = _systemContext.Set<Profile>().CreateProxy();
            var nextOrdinalNumber = await GetMaxOrdinalNumberAsync().ConfigureAwait(false) + 1;

            var id = _idGenerator.Generate();
            createdProfile.Initialize(
                id: id,
                userId: user.Id,
                ordinalNumber: nextOrdinalNumber);

            var newProfile = _systemContext.Set<Profile>().Add(createdProfile);

            return newProfile.Entity;
        }

        public async Task<Profile[]> GetAllAsync()
        {
            var profiles = await _systemContext.Set<Profile>().ToArrayAsync().ConfigureAwait(false);

            /*проверка на NULL*/

            return profiles;
        }

        public async Task<Profile> GetAsync(Guid id)
        {
            var profile = await _systemContext.Set<Profile>().SingleOrDefaultAsync(ctx => ctx.Id == id);

            /*проверка на NULL*/

            return profile;
        }

        public async Task<Profile> GetByOrdinalNumberAsync(long ordinalNumber)
        {
            var profile = await _systemContext.Set<Profile>().SingleOrDefaultAsync(ctx => ctx.OrdinalNumber == ordinalNumber);

            /*проверка на NULL*/

            return profile;
        }

        private async Task<long> GetMaxOrdinalNumberAsync()
        {
            var ordNumbers = await _systemContext.Set<Profile>().Where(profile => profile != null).Select(profile => profile.OrdinalNumber).ToArrayAsync().ConfigureAwait(false);
            var maxOrdinalNumber = ordNumbers.Any() ? ordNumbers.Max() : 0L;

            /*проверка на NULL*/

            return maxOrdinalNumber;
        }

        public async Task UpdateAsync(Guid profileId, ProfileDto newProfileData)
        {
            Contract.Argument.IsNotEmptyGuid(profileId, nameof(profileId));
            Contract.Argument.IsNotNull(newProfileData, nameof(newProfileData));

            var oldProfileData = await GetAsync(profileId).ConfigureAwait(false);

            var avatar = Convert.FromBase64String(newProfileData.Avatar as string);

            oldProfileData.Update(
                avatar: avatar,
                webpages: newProfileData.WebPages);
        }
    }
}
