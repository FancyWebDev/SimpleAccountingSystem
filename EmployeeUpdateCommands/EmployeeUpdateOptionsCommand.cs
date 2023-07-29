using System;
using System.Collections.Generic;

namespace SimpleEmployeeAccountingSystem.EmployeeUpdateCommands
{
    public class EmployeeUpdateOptionsCommand : ICommand
    {
        private readonly Employee _employee;
        private readonly EmployeeUpdateCommandFactory _employeeUpdateCommandFactory;

        private readonly Dictionary<byte, string> _commandsToPrint = new()
        {
            { 0, "Back to menu" },
            { 1, "Update name" },
            { 2, "Update age" },
            { 3, "Update post" },
        };

        public EmployeeUpdateOptionsCommand(Employee employee, EmployeeUpdateCommandFactory employeeUpdateCommandFactory)
        {
            _employee = employee;
            _employeeUpdateCommandFactory = employeeUpdateCommandFactory;
        }

        public void Execute()
        {
            Console.WriteLine("\nSelect label to change");
            PrintEmployeeOptions();

            Console.Write("\nType command number: ");
            var input = Console.ReadLine();
            HandleUserInput(input);
        }

        private void PrintEmployeeOptions()
        {
            foreach (var (number, commandName) in _commandsToPrint)
                Console.WriteLine($"{number} - {commandName}");
        }

        private void HandleUserInput(string? value)
        {
            var commandType = value switch
            {
                "0" => EmployeeUpdateCommandType.Exit,
                "1" => EmployeeUpdateCommandType.UpdateName,
                "2" => EmployeeUpdateCommandType.UpdateAge,
                "3" => EmployeeUpdateCommandType.UpdatePost,
                _ => EmployeeUpdateCommandType.EmployeeUpdateOptions
            };

            _employeeUpdateCommandFactory
                .Create(commandType, _employee)
                .Execute();
        }
    }
}