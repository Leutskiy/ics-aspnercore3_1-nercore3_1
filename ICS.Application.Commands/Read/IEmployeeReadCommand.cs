using ICS.WebApplication.Commands.Read.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.WebApplication.Commands.Read
{
	public interface IEmployeeReadCommand
	{
		Task<IEnumerable<InvitationResult>> ExecuteAllAsync(Guid employeeId);
	}
}