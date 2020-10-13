using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Models;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using ICS.WebApplication.Commands.Read.Contracts;
using ICS.WebApplication.Commands.Read.Results;
using System;
using System.Threading.Tasks;

namespace ICS.WebApplication.Commands.Read
{
    /// <summary>
    /// Команда персистенса информации по профилю пользователя
    /// </summary>
    public sealed class ProfileWriteCommand
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPassportRepository _passportRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IStateRegistrationRepository _stateRegistrationRepository;
        private readonly IReadCommand<PassportResult> _passportReadCommand;
        private readonly IReadCommand<ContactResult> _contactReadCommand;
        private readonly IEmployeeService _employeeService;
        private readonly SystemContext _systemContext;

        public ProfileWriteCommand(
            IProfileRepository profileRepository,
            IEmployeeRepository employeeRepository,
            IPassportRepository passportRepository,
            IContactRepository contactRepository,
            IOrganizationRepository organizationRepository,
            IStateRegistrationRepository stateRegistrationRepository,
            IReadCommand<PassportResult> passportReadCommand,
            IReadCommand<ContactResult> contactReadCommand,
            IEmployeeService employeeService,
            SystemContext systemContext)
        {
            Contract.Argument.IsNotNull(profileRepository, nameof(profileRepository));
            Contract.Argument.IsNotNull(employeeRepository, nameof(employeeRepository));
            Contract.Argument.IsNotNull(passportRepository, nameof(passportRepository));
            Contract.Argument.IsNotNull(contactRepository, nameof(contactRepository));
            Contract.Argument.IsNotNull(organizationRepository, nameof(organizationRepository));
            Contract.Argument.IsNotNull(stateRegistrationRepository, nameof(stateRegistrationRepository));
            Contract.Argument.IsNotNull(passportReadCommand, nameof(passportReadCommand));
            Contract.Argument.IsNotNull(contactReadCommand, nameof(contactReadCommand));
            Contract.Argument.IsNotNull(employeeService, nameof(employeeService));
            Contract.Argument.IsNotNull(systemContext, nameof(systemContext));

            _profileRepository = profileRepository;
            _employeeRepository = employeeRepository;
            _passportRepository = passportRepository;
            _contactRepository = contactRepository;
            _organizationRepository = organizationRepository;
            _stateRegistrationRepository = stateRegistrationRepository;
            _passportReadCommand = passportReadCommand;
            _contactReadCommand = contactReadCommand;
            _employeeService = employeeService;
            _systemContext = systemContext;
        }

        /// <summary>
        /// Выполнить команду Обновить профиль
        /// </summary>
        /// <param name="profileId">Идентификатор профиля</param>
        /// <param name="profileDto">Данные по профилю</param>
        public async Task UpdateAsync(Guid profileId, ProfileDto profileDto)
        {
            Contract.Argument.IsNotEmptyGuid(profileId, nameof(profileId));
            Contract.Argument.IsNotNull(profileDto, nameof(profileDto));

            await _profileRepository.UpdateAsync(profileId, profileDto).ConfigureAwait(false);

            _systemContext.SaveChanges();
        }
    }
}
