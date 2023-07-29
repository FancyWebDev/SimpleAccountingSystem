namespace SimpleEmployeeAccountingSystem.EmployeeUpdateCommands
{
    public class ExitEmployeeUpdateMenuCommand : ICommand
    {
        private readonly App _app;

        public ExitEmployeeUpdateMenuCommand(App app)
        {
            _app = app;
        }
        
        public void Execute() => _app.ExecuteMenuCommand(MenuCommandType.MenuOptions);
    }
}