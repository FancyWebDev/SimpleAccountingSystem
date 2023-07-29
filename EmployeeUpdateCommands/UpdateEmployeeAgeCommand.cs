using System;

namespace SimpleEmployeeAccountingSystem.EmployeeUpdateCommands
{
    public class UpdateEmployeeAgeCommand : ICommand
    {
        private readonly EmployeeManagement _employeeManagement;
        private readonly Employee _employee;

        public UpdateEmployeeAgeCommand(EmployeeManagement employeeManagement, Employee employeeToUpdate)
        {
            _employeeManagement = employeeManagement;
            _employee = employeeToUpdate;
        }

        public void Execute()
        {
            var input = Extension.GetNaturalInt("Type new age: ", "Age must be a number and greater than 0");
            var updatedEmployee = new Employee(_employee.Id, _employee.Name, Convert.ToInt32(input), _employee.Post);
            _employeeManagement.UpdateEmployee(updatedEmployee);
        }
    }
}