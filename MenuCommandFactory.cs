using System;
using SimpleEmployeeAccountingSystem.MenuCommands;

namespace SimpleEmployeeAccountingSystem
{
    public class MenuCommandFactory
    {
        private readonly EmployeeManagement _employeeManagement;
        private readonly EmployeeUpdateCommandFactory _employeeUpdateCommandFactory;
        private readonly App _app;

        public MenuCommandFactory(
            EmployeeManagement employeeManagement, 
            EmployeeUpdateCommandFactory employeeUpdateCommandFactory,
            App app)
        {
            _employeeManagement = employeeManagement;
            _employeeUpdateCommandFactory = employeeUpdateCommandFactory;
            _app = app;
        }

        public ICommand Create(MenuCommandType type)
        {
            return type switch
            {
                MenuCommandType.Exit => new ExitCommand(_app),
                MenuCommandType.AddEmployee => new AddEmployeeCommand(_employeeManagement),
                MenuCommandType.RemoveEmployee =>  new RemoveEmployeeCommand(_employeeManagement),
                MenuCommandType.PrintAllEmployees => new PrintAllEmployeesCommand(_employeeManagement),
                MenuCommandType.PrintEmployeeById => new PrintEmployeeByIdCommand(_employeeManagement),
                MenuCommandType.UpdateEmployee =>  new UpdateEmployeeCommand(_employeeManagement, _employeeUpdateCommandFactory),
                MenuCommandType.MenuOptions => new MenuOptionsCommand(_app),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}