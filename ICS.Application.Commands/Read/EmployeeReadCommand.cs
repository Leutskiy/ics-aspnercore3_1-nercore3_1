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
    /// Команда чтения сотрудников
    /// </summary>
    public sealed partial class EmployeeReadCommand : IReadCommand<EmployeeResult>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IReadCommand<ContactResult> _contactReadCommand;
        private readonly IReadCommand<PassportResult> _passportReadCommand;
        private readonly IReadCommand<OrganizationResult> _organizationReadCommand;
        private readonly IReadCommand<StateRegistrationResult> _stateRegistrationReadCommand;

        public EmployeeReadCommand(
            IEmployeeRepository employeeRepository,
            IReadCommand<ContactResult> contactReadCommand,
            IReadCommand<PassportResult> passportReadCommand,
            IReadCommand<OrganizationResult> organizationReadCommand,
            IReadCommand<StateRegistrationResult> stateRegistrationReadCommand)
        {
            Contract.Argument.IsNotNull(employeeRepository, nameof(employeeRepository));
            Contract.Argument.IsNotNull(contactReadCommand, nameof(contactReadCommand));
            Contract.Argument.IsNotNull(passportReadCommand, nameof(passportReadCommand));
            Contract.Argument.IsNotNull(organizationReadCommand, nameof(organizationReadCommand));
            Contract.Argument.IsNotNull(stateRegistrationReadCommand, nameof(stateRegistrationReadCommand));

            _employeeRepository = employeeRepository;
            _contactReadCommand = contactReadCommand;
            _passportReadCommand = passportReadCommand;
            _organizationReadCommand = organizationReadCommand;
            _stateRegistrationReadCommand = stateRegistrationReadCommand;
        }

        /// <summary>
        /// Выполнить команду на чтение информации по сотруднику
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <returns>Информация по сотруднику</returns>
        public async Task<EmployeeResult> ExecuteAsync(Guid employeeId)
        {
            Contract.Argument.IsNotEmptyGuid(employeeId, nameof(employeeId));

            var employee = await _employeeRepository.GetAsync(employeeId).ConfigureAwait(false);

            var contactResult = employee.ContactId.HasValue ? await _contactReadCommand.ExecuteAsync(employee.ContactId.Value).ConfigureAwait(false) : null;
            var passportResult = employee.PassportId.HasValue ? await _passportReadCommand.ExecuteAsync(employee.PassportId.Value).ConfigureAwait(false) : null;
            var organizationResult = employee.OrganizationId.HasValue ? await _organizationReadCommand.ExecuteAsync(employee.OrganizationId.Value).ConfigureAwait(false) : null;
            var stateRegistrationResult = employee.StateRegistrationId.HasValue ? await _stateRegistrationReadCommand.ExecuteAsync(employee.StateRegistrationId.Value).ConfigureAwait(false) : null;

            return DomainEntityConverter.ConvertToResult(
                employee: employee,
                contactResult: contactResult,
                passportResult: passportResult,
                organizationResult: organizationResult,
                stateRegistrationResult: stateRegistrationResult);
        }

        public Task<IEnumerable<EmployeeResult>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}