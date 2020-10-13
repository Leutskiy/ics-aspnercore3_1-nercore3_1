using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Models;
using ICS.Shared;
using ICS.WebApplication.Commands.Read;
using ICS.WebApplication.Commands.Read.Contracts;
using ICS.WebApplication.Commands.Read.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ICS.WebApp.Controllers
{
    /// <summary>
    /// Контроллер информации по сотруднику
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeWriteCommand _employeeWriteCommand;
        private readonly IReadCommand<EmployeeResult> _employeeReadCommand;

        public EmployeeController(
            IEmployeeRepository employeeRepository,
            EmployeeWriteCommand employeeWriteCommand,
            IReadCommand<EmployeeResult> employeeReadCommand)
        {
            Contract.Argument.IsNotNull(employeeRepository, nameof(employeeRepository));
            Contract.Argument.IsNotNull(employeeWriteCommand, nameof(employeeWriteCommand));
            Contract.Argument.IsNotNull(employeeReadCommand, nameof(employeeReadCommand));

            _employeeRepository = employeeRepository;
            _employeeWriteCommand = employeeWriteCommand;
            _employeeReadCommand = employeeReadCommand;
        }

        [HttpGet]
        [Route("{employeeId:guid}")]
        public async Task<EmployeeResult> GetAsync(Guid employeeId)
        {
            return await _employeeReadCommand.ExecuteAsync(employeeId).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("{employeeId:guid}/scientific")]
        public async Task UpdateScientificInfoAsync(Guid employeeId, ScientificInfoDto scientificInfo)
        {
            Contract.Argument.IsNotNull(scientificInfo, nameof(scientificInfo));

            await _employeeWriteCommand.UpdateEmployeeScientificInfoAsync(employeeId, scientificInfo).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("{employeeId:guid}/job")]
        public async Task UpdateJobAsync(Guid employeeId, JobDto jobData)
        {
            Contract.Argument.IsNotNull(jobData, nameof(jobData));

            await _employeeWriteCommand.UpdateEmployeeJobAsync(employeeId, jobData).ConfigureAwait(false);
        }
    }
}