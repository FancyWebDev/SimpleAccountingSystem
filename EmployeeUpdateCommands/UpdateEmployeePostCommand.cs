namespace SimpleEmployeeAccountingSystem.EmployeeUpdateCommands
{
    public class UpdateEmployeePostCommand : ICommand
    {
        private readonly EmployeeManagement _employeeManagement;
        private readonly Employee _employee;

        public UpdateEmployeePostCommand(EmployeeManagement employeeManagement, Employee employee)
        {
            _employeeManagement = employeeManagement;
            _employee = employee;
        }

        public void Execute()
        {
            var input = Extension.GetNotEmptyString("Type new post: ", "Post must contain at least 2 characters", 2);
            var updatedEmployee = new Employee(_employee.Id, _employee.Name, _employee.Age, input);
            _employeeManagement.UpdateEmployee(updatedEmployee);
        }
    }
}