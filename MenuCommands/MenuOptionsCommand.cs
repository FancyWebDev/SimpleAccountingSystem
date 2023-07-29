using System;
using System.Collections.Generic;

namespace SimpleEmployeeAccountingSystem.MenuCommands
{
    public class MenuOptionsCommand : ICommand
    {
        private readonly App _app;

        private readonly Dictionary<byte, string> _commandsToPrint = new()
        {
            { 0, "Exit" },
            { 1, "Add employee" },
            { 2, "Remove employee" },
            { 3, "Print all employees" },
            { 4, "Print employee by id" },
            { 5, "Update employee" }
        };

        public MenuOptionsCommand(App app)
        {
            _app = app;
        }

        public void Execute()
        {
            PrintMenuOptions();
            Console.Write("\nType command number: ");
            var input = Console.ReadLine();
            HandleUserInput(input);
        }

        private void HandleUserInput(string? value)
        {
            var commandType = value switch
            {
                "0" => MenuCommandType.Exit,
                "1" => MenuCommandType.AddEmployee,
                "2" => MenuCommandType.RemoveEmployee,
                "3" => MenuCommandType.PrintAllEmployees,
                "4" => MenuCommandType.PrintEmployeeById,
                "5" => MenuCommandType.UpdateEmployee,
                _ => MenuCommandType.MenuOptions
            };

            _app.ExecuteMenuCommand(commandType);
        }

        private void PrintMenuOptions()
        {
            foreach (var (number, commandName) in _commandsToPrint)
                Console.WriteLine($"{number} - {commandName}");
        }
    }
}