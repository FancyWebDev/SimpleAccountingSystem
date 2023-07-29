using System;
using System.Collections.Generic;

namespace SimpleEmployeeAccountingSystem
{
    public class App
    {
        private readonly Dictionary<MenuCommandType, ICommand> _menuCommands;

        private bool _isRunning;

        public App(EmployeeManagement employeeManagement)
        {
            var employeeUpdateCommandFactory = new EmployeeUpdateCommandFactory(employeeManagement, this);
            var menuCommandFactory = new MenuCommandFactory(employeeManagement, employeeUpdateCommandFactory, this);

            _menuCommands = new Dictionary<MenuCommandType, ICommand>
            {
                { MenuCommandType.Exit, menuCommandFactory.Create(MenuCommandType.Exit) },
                { MenuCommandType.AddEmployee, menuCommandFactory.Create(MenuCommandType.AddEmployee) },
                { MenuCommandType.RemoveEmployee, menuCommandFactory.Create(MenuCommandType.RemoveEmployee) },
                { MenuCommandType.PrintAllEmployees, menuCommandFactory.Create(MenuCommandType.PrintAllEmployees) },
                { MenuCommandType.PrintEmployeeById, menuCommandFactory.Create(MenuCommandType.PrintEmployeeById) },
                { MenuCommandType.UpdateEmployee, menuCommandFactory.Create(MenuCommandType.UpdateEmployee) },
                { MenuCommandType.MenuOptions, menuCommandFactory.Create(MenuCommandType.MenuOptions) },
            };
        }

        public void Start()
        {
            _isRunning = true;

            Console.WriteLine("Employee Accounting System");
            while (_isRunning)
            {
                _menuCommands[MenuCommandType.MenuOptions].Execute();
            }
        }

        public void Stop() => _isRunning = false;

        public void ExecuteMenuCommand(MenuCommandType menuCommandType)
        {
            _menuCommands[menuCommandType].Execute();
        }
    }
}