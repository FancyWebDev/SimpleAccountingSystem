namespace SimpleEmployeeAccountingSystem.MenuCommands
{
    public class PrintAllEmployeesCommand : ICommand
    {
        private readonly EmployeeManagement _employeeManagement;

        public PrintAllEmployeesCommand(EmployeeManagement employeeManagement)
        {
            _employeeManagement = employeeManagement;
        }

        public void Execute()
        {
            _employeeManagement
                .GetAllEmployees()
                .PrintInfo();
        }
    }
}