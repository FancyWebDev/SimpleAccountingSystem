using System;

namespace SimpleEmployeeAccountingSystem.MenuCommands
{
    public class PrintEmployeeByIdCommand : ICommand
    {
        private readonly EmployeeManagement _employeeManagement;

        public PrintEmployeeByIdCommand(EmployeeManagement employeeManagement)
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

            if(_employeeManagement.GetEmployee(employeeId, out var employee))
                employee.PrintInfo();
            else
                Extension.PrintEmployeeDoesNotExist(employeeId);
        }
    }
}