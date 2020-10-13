using ICS.Domain.Entities;
using ICS.Domain.Models;
using System;

namespace ICS.Domain.Services.Contracts
{
    public interface IEmployeeService
    {
        Employee Add(EmployeeDto addedEmployee);

        void UpdateStateRegistration(Employee employee, Guid stateRegistrationId);
    }
}