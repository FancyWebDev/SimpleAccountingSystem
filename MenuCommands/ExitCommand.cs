namespace SimpleEmployeeAccountingSystem.MenuCommands
{
    public class ExitCommand : ICommand
    {
        private readonly App _app;

        public ExitCommand(App app)
        {
            _app = app;
        }

        public void Execute() => _app.Stop();
    }
}