using System;

namespace SimpleEmployeeAccountingSystem.MenuCommands
{
    public class RemoveEmployeeCommand : ICommand
    {
        private readonly EmployeeManagement _employeeManagement;

        public RemoveEmployeeCommand(EmployeeManagement employeeManagement)
        {
            _employeeManagement = employeeManagement;
        }

        public void Execute()
        {
            Console.Write("Type employee id: ");
            var input = Console.ReadLine();

            if (byte.TryParse(input, out var employeeId) == false)
            {
                Extension.PrintIdMustBeNumber();
                return;
            }
            
            if (_employeeManagement.Contains(employeeId) == false)
            {
                Extension.PrintEmployeeDoesNotExist(employeeId);
                return;
            }
                
            _employeeManagement.RemoveEmployee(employeeId);
        }
    }
}