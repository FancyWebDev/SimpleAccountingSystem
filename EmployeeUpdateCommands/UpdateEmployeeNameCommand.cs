namespace SimpleEmployeeAccountingSystem.EmployeeUpdateCommands
{
    public class UpdateEmployeeNameCommand : ICommand
    {
        private readonly EmployeeManagement _employeeManagement;
        private readonly Employee _employee;

        public UpdateEmployeeNameCommand(EmployeeManagement employeeManagement, Employee employeeToUpdate)
        {
            _employeeManagement = employeeManagement;
            _employee = employeeToUpdate;
        }
        
        public void Execute()
        {
            var input = Extension.GetNotEmptyString("Type new name: ", "Name must contain at least 2 characters", 2);
            var updatedEmployee = new Employee(_employee.Id, input, _employee.Age, _employee.Post);
            
            _employeeManagement.UpdateEmployee(updatedEmployee);
        }
    }
}