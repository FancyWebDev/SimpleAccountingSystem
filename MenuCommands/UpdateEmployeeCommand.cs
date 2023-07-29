using System;

namespace SimpleEmployeeAccountingSystem.MenuCommands
{
    public class UpdateEmployeeCommand : ICommand
    {
        private readonly EmployeeManagement _employeeManagement;
        private readonly EmployeeUpdateCommandFactory _employeeUpdateCommandFactory;

        public UpdateEmployeeCommand(
            EmployeeManagement employeeManagement, 
            EmployeeUpdateCommandFactory employeeUpdateCommandFactory)
        {
            _employeeManagement = employeeManagement;
            _employeeUpdateCommandFactory = employeeUpdateCommandFactory;
        }

        public void Execute()
        {
            Console.Write("Type employee id: ");
            var input = Console.ReadLine();
            var employeeId = Convert.ToByte(input);
            _employeeManagement.GetEmployee(employeeId, out var employee);
            
            employee.PrintInfo();
            _employeeUpdateCommandFactory
                .Create(EmployeeUpdateCommandType.EmployeeUpdateOptions, employee)
                .Execute();
        }
    }
}