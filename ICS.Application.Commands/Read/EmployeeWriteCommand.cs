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
    /// Команда персистенса информации по сотруднику
    /// </summary>
    public sealed class EmployeeWriteCommand
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPassportRepository _passportRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IStateRegistrationRepository _stateRegistrationRepository;
        private readonly IReadCommand<PassportResult> _passportReadCommand;
        private readonly IReadCommand<ContactResult> _contactReadCommand;
        private readonly IEmployeeService _employeeService;
        private readonly DomainContext _domainContext;

        public EmployeeWriteCommand(
            IEmployeeRepository employeeRepository,
            IPassportRepository passportRepository,
            IContactRepository contactRepository,
            IOrganizationRepository organizationRepository,
            IStateRegistrationRepository stateRegistrationRepository,
            IReadCommand<PassportResult> passportReadCommand,
            IReadCommand<ContactResult> contactReadCommand,
            IEmployeeService employeeService,
            DomainContext domainContext)
        {
            Contract.Argument.IsNotNull(employeeRepository, nameof(employeeRepository));
            Contract.Argument.IsNotNull(passportRepository, nameof(passportRepository));
            Contract.Argument.IsNotNull(contactRepository, nameof(contactRepository));
            Contract.Argument.IsNotNull(organizationRepository, nameof(organizationRepository));
            Contract.Argument.IsNotNull(stateRegistrationRepository, nameof(stateRegistrationRepository));
            Contract.Argument.IsNotNull(passportReadCommand, nameof(passportReadCommand));
            Contract.Argument.IsNotNull(contactReadCommand, nameof(contactReadCommand));
            Contract.Argument.IsNotNull(employeeService, nameof(employeeService));
            Contract.Argument.IsNotNull(domainContext, nameof(domainContext));

            _employeeRepository = employeeRepository;
            _passportRepository = passportRepository;
            _contactRepository = contactRepository;
            _organizationRepository = organizationRepository;
            _stateRegistrationRepository = stateRegistrationRepository;
            _passportReadCommand = passportReadCommand;
            _contactReadCommand = contactReadCommand;
            _employeeService = employeeService;
            _domainContext = domainContext;
        }

        /// <summary>
        /// Выполнить команду Добавить или Обновить паспортные данные сотрудника
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="employeeDto">Паспортные данные для создания паспорта</param>
        /// <returns>Идентификатор паспорта</returns>
        public async Task<Guid> AddOrUpdatePassportAsync(Guid employeeId, PassportDto passportDto)
        {
            Contract.Argument.IsNotEmptyGuid(employeeId, nameof(employeeId));
            Contract.Argument.IsNotNull(passportDto, nameof(passportDto));

            var employee = await _employeeRepository.GetAsync(employeeId).ConfigureAwait(false);

            if (employee.PassportId.HasValue)
            {
                await _passportRepository.UpdateAsync(employee.PassportId.Value, passportDto).ConfigureAwait(false);
            }
            else
            {
                var passport = _passportRepository.Create(
                    nameRus: passportDto.NameRus,
                    surnameRus: passportDto.SurnameRus,
                    nameEng: passportDto.NameEng,
                    surnameEng: passportDto.SurnameEng,
                    patronymicNameRus: passportDto.PatronymicNameRus,
                    patronymicNameEng: passportDto.PatronymicNameEng,
                    birthPlace: passportDto.BirthPlace,
                    birthCountry: passportDto.BirthCountry,
                    departmentCode: passportDto.DepartmentCode,
                    citizenship: passportDto.Citizenship,
                    identityDocument: passportDto.IdentityDocument,
                    residence: passportDto.Residence,
                    residenceCountry: passportDto.ResidenceCountry,
                    residenceRegion: passportDto.ResidenceRegion,
                    issuePlace: passportDto.IssuePlace,
                    birthDate: passportDto.BirthDate,
                    issueDate: passportDto.IssueDate,
                    gender: passportDto.Gender);

                employee.SetPassportId(passport.Id);
            }

            _domainContext.SaveChanges();

            return employee.PassportId.Value;
        }

        /// <summary>
        /// Выполнить команду Добавить или Обновить контактные данные сотрудника
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="contactDto">Контактные данные для создания контакта</param>
        /// <returns>Идентификатор контакта</returns>
        public async Task<Guid> AddOrUpdateContactAsync(Guid employeeId, ContactDto contactDto)
        {
            Contract.Argument.IsNotEmptyGuid(employeeId, nameof(employeeId));
            Contract.Argument.IsNotNull(contactDto, nameof(contactDto));

            var employee = await _employeeRepository.GetAsync(employeeId).ConfigureAwait(false);

            if (employee.ContactId.HasValue)
            {
                await _contactRepository.UpdateAsync(employee.ContactId.Value, contactDto).ConfigureAwait(false);
            }
            else
            {
                var contact = _contactRepository.Create(
                    email: contactDto.Email,
                    postcode: contactDto.Postcode,
                    homePhoneNumber: contactDto.HomePhoneNumber,
                    workPhoneNumber: contactDto.WorkPhoneNumber,
                    mobilePhoneNumber: contactDto.MobilePhoneNumber);

                employee.SetContactId(contact.Id);
            }

            _domainContext.SaveChanges();


            return employee.ContactId.Value;
        }

        /// <summary>
        /// Выполнить команду Добавить или Обновить данные по организации сотрудника
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="organizationDto">Данные по организации для создания организации</param>
        /// <returns>Идентификатор контакта</returns>
        public async Task<Guid> AddOrUpdateOrganizationAsync(Guid employeeId, OrganizationDto organizationDto)
        {
            Contract.Argument.IsNotEmptyGuid(employeeId, nameof(employeeId));
            Contract.Argument.IsNotNull(organizationDto, nameof(organizationDto));

            var employee = await _employeeRepository.GetAsync(employeeId).ConfigureAwait(false);

            if (employee.OrganizationId.HasValue)
            {
                var organization = await _organizationRepository.GetAsync(employee.OrganizationId.Value).ConfigureAwait(false);
                await _stateRegistrationRepository.UpdateAsync(organization.StateRegistrationId, organizationDto.StateRegistration).ConfigureAwait(false);
                await _organizationRepository.UpdateAsync(employee.OrganizationId.Value, organizationDto).ConfigureAwait(false);
            }
            else
            {
                var stateRegistration = _stateRegistrationRepository.Create(
                    inn: organizationDto.StateRegistration.Inn,
                    ogrnip: organizationDto.StateRegistration.Ogrnip);

                var organization = _organizationRepository.Create(
                    stateRegistrationId: stateRegistration.Id,
                    name: organizationDto.Name,
                    shortName: organizationDto.ShortName,
                    legalAddress: organizationDto.LegalAddress,
                    scientificActivity: organizationDto.ScientificActivity);

                employee.SetOrganizationId(organization.Id);
            }

            _domainContext.SaveChanges();

            return employee.OrganizationId.Value;
        }

        /// <summary>
        /// Выполнить команду Добавить или Обновить государственные регистрацонные данные сотрудника
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="stateRegistrationDto">Государственные регистрацонные данные</param>
        /// <returns>Идентификатор государственных регистрационных данных</returns>
        public async Task<Guid> AddOrUpdateStateRegistrationAsync(Guid employeeId, StateRegistrationDto stateRegistrationDto)
        {
            Contract.Argument.IsNotEmptyGuid(employeeId, nameof(employeeId));
            Contract.Argument.IsNotNull(stateRegistrationDto, nameof(stateRegistrationDto));

            // плохо
            var employee = await _employeeRepository.GetAsync(employeeId).ConfigureAwait(false);

            if (employee.StateRegistrationId.HasValue)
            {
                await _stateRegistrationRepository.UpdateAsync(employee.StateRegistrationId.Value, stateRegistrationDto).ConfigureAwait(false);
            }
            else
            {
                var newStateRegistration = _stateRegistrationRepository.Create(stateRegistrationDto.Inn, stateRegistrationDto.Ogrnip);
                _employeeService.UpdateStateRegistration(employee, newStateRegistration.Id);
            }

            _domainContext.SaveChanges();

            return employee.OrganizationId.Value;
        }

        /// <summary>
        /// Выполнить команду Обновить сотрудника
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="scientificInfoDto">Данные по сотруднику</param>
        public async Task UpdateEmployeeScientificInfoAsync(Guid employeeId, ScientificInfoDto scientificInfoDto)
        {
            Contract.Argument.IsNotEmptyGuid(employeeId, nameof(employeeId));
            Contract.Argument.IsNotNull(scientificInfoDto, nameof(scientificInfoDto));

            await _employeeRepository.UpdateScientificInfoAsync(employeeId, scientificInfoDto).ConfigureAwait(false);

            _domainContext.SaveChanges();
        }

        /// <summary>
        /// Выполнить команду Обновить сотрудника
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="jobDto">Данные по сотруднику</param>
        public async Task UpdateEmployeeJobAsync(Guid employeeId, JobDto jobDto)
        {
            Contract.Argument.IsNotEmptyGuid(employeeId, nameof(employeeId));
            Contract.Argument.IsNotNull(jobDto, nameof(jobDto));

            await _employeeRepository.UpdateJobAsync(employeeId, jobDto).ConfigureAwait(false);

            _domainContext.SaveChanges();
        }
    }
}
