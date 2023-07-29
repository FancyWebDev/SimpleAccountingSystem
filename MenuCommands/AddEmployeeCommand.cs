using System;

namespace SimpleEmployeeAccountingSystem.MenuCommands
{
    public class AddEmployeeCommand : ICommand
    {
        private readonly EmployeeManagement _employeeManagement;
        
        public AddEmployeeCommand(EmployeeManagement employeeManagement)
        {
            _employeeManagement = employeeManagement;
        }
        
        public void Execute()
        {
            var name = Extension.GetNotEmptyString("Type name: ", "Name must contain at least 2 characters", 2);
            var age = Extension.GetNaturalInt("Type age: ", "Age must be a number and greater than 0");
            var post = Extension.GetNotEmptyString("Type post: ", "Post must contain at least 2 characters", 2);
            
            _employeeManagement.AddEmployee(name, Convert.ToInt32(age), post);
        }
    }
}