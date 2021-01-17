using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Models;
using ICS.Shared;
using ICS.WebApplication.Commands.Read;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ICS.WebApp.Controllers
{
	/// <summary>
	/// Контроллер государственных регистрационных данных
	/// </summary>
	[ApiController]
    [Authorize]
    [Route("api/v1/stateregistration")]
    public class StateRegistrationController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly InvitationWriteCommand _employeeWriteCommand;

        public StateRegistrationController(
            IEmployeeRepository employeeRepository,
            InvitationWriteCommand employeeWriteCommand)
        {
            _employeeRepository = employeeRepository;
            _employeeWriteCommand = employeeWriteCommand;
        }

        [HttpPost]
        [Route("{stateregistrationId:guid?}")]
        public async Task<Guid> AddOrUpdateAsync(Guid? stateRegistrationId, StateRegistrationDto createdStateRegistrationData)
        {
            Contract.Argument.IsNotNull(createdStateRegistrationData, nameof(createdStateRegistrationData));

            var employeeId = await GetEmployeeIdAsync().ConfigureAwait(false);
            return await _employeeWriteCommand.AddOrUpdateStateRegistrationAsync(employeeId, createdStateRegistrationData).ConfigureAwait(false);
        }

        private async Task<Guid> GetEmployeeIdAsync()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identityClaims.FindFirst("UserId").Value);
            var employee = await _employeeRepository.GetByUserIdAsync(userId).ConfigureAwait(false);

            return employee.Id;
        }
    }
}