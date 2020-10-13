using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Models;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using System;

namespace ICS.Domain.Services
{
    /// <summary>
    /// Сервис по работе с сотрудниками
    /// </summary>
    public sealed class EmployeeService : IEmployeeService
    {
        private readonly IUserInfoProvider _userContextPrtovider;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IContactService _contactService;
        private readonly IPassportService _passportService;
        private readonly IOrganizationService _organizationService;
        private readonly IStateRegistrationService _stateRegistrationService;
        private readonly DomainContext _domainContext;

        public EmployeeService(
            IUserInfoProvider userContextPrtovider,
            IEmployeeRepository employeeRepository,
            IContactService contactService,
            IPassportService passportService,
            IOrganizationService organizationService,
            IStateRegistrationService stateRegistrationService,
            DomainContext domainContext)
        {
            Contract.Argument.IsNotNull(userContextPrtovider, nameof(userContextPrtovider));
            Contract.Argument.IsNotNull(employeeRepository, nameof(employeeRepository));
            Contract.Argument.IsNotNull(contactService, nameof(contactService));
            Contract.Argument.IsNotNull(passportService, nameof(passportService));
            Contract.Argument.IsNotNull(organizationService, nameof(organizationService));
            Contract.Argument.IsNotNull(stateRegistrationService, nameof(stateRegistrationService));
            Contract.Argument.IsNotNull(domainContext, nameof(domainContext));

            _userContextPrtovider = userContextPrtovider;
            _employeeRepository = employeeRepository;
            _contactService = contactService;
            _passportService = passportService;
            _organizationService = organizationService;
            _stateRegistrationService = stateRegistrationService;
            _domainContext = domainContext;
        }

        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="addedEmployee">DTO добавляемого сотрудника</param>
        /// <returns>Сотрудник</returns>
        public Employee Add(EmployeeDto addedEmployee)
        {
            Contract.Argument.IsNotNull(addedEmployee, nameof(addedEmployee));

            var userId = _userContextPrtovider.GetUserId();
            var contact = _contactService.Add(addedEmployee.Contact);
            var passport = _passportService.Add(addedEmployee.Passport);
            var organization = _organizationService.Add(addedEmployee.Organization);
            var stateRegistration = _stateRegistrationService.Add(addedEmployee.StateRegistration);

            var newEmployee = _employeeRepository.Create(
                userId: userId,
                managerId: addedEmployee.ManagerId,
                contactId: contact.Id,
                passportId: passport.Id,
                invitationId: null,
                organizationId: organization.Id,
                stateRegistrationId: stateRegistration.Id,
                academicDegree: addedEmployee.AcademicDegree,
                academicRank: addedEmployee.AcademicRank,
                education: addedEmployee.Education,
                position: addedEmployee.Position,
                workPlace: addedEmployee.WorkPlace);

            return newEmployee;
        }

        public void UpdateStateRegistration(Employee employee, Guid stateRegistrationId)
        {
            Contract.Argument.IsNotNull(employee, nameof(employee));
            Contract.Argument.IsNotEmptyGuid(stateRegistrationId, nameof(stateRegistrationId));

            employee.SetStateRegistrationId(stateRegistrationId);

            _domainContext.SaveChanges();
        }
    }
}