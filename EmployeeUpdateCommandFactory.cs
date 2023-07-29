using System;
using SimpleEmployeeAccountingSystem.EmployeeUpdateCommands;

namespace SimpleEmployeeAccountingSystem
{
    public class EmployeeUpdateCommandFactory
    {
        private readonly EmployeeManagement _employeeManagement;
        private readonly App _app;

        public EmployeeUpdateCommandFactory(
            EmployeeManagement employeeManagement, 
            App app)
        {
            _employeeManagement = employeeManagement;
            _app = app;
        }

        public ICommand Create(EmployeeUpdateCommandType type, Employee employeeToUpdate)
        {
            return type switch
            {
                EmployeeUpdateCommandType.Exit => new ExitEmployeeUpdateMenuCommand(_app),
                EmployeeUpdateCommandType.UpdateName => new UpdateEmployeeNameCommand(_employeeManagement, employeeToUpdate),
                EmployeeUpdateCommandType.UpdateAge => new UpdateEmployeeAgeCommand(_employeeManagement, employeeToUpdate),
                EmployeeUpdateCommandType.UpdatePost => new UpdateEmployeePostCommand(_employeeManagement, employeeToUpdate),
                EmployeeUpdateCommandType.EmployeeUpdateOptions => new EmployeeUpdateOptionsCommand(employeeToUpdate, this),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}