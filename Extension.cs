using System;
using System.Collections.Generic;
using ConsoleTables;

namespace SimpleEmployeeAccountingSystem
{
    public static class Extension
    {
        public static void PrintInfo(this IEnumerable<Employee> employees)
        {
            var consoleTable = new ConsoleTable("Id", "Name", "Age", "Post");
            
            foreach (var employee in employees)
            {
                var (id, name, age, post) = employee;
                consoleTable.AddRow(id, name, age, post);
            }

            consoleTable.Write(Format.Minimal);
        }

        public static void PrintInfo(this Employee employee)
        {
            var consoleTable = new ConsoleTable("Id", "Name", "Age", "Post");
            var (id, name, age, post) = employee;
            
            consoleTable.AddRow(id, name, age, post);
            consoleTable.Write(Format.Minimal);
        }

        public static void PrintEmployeeDoesNotExist(int id) => Console.WriteLine($"Employee with id={id} doesn't exist");

        public static void PrintIdMustBeNumber() => Console.WriteLine("Id must be a number");

        public static uint GetNaturalInt(string message, string errorMessage)
        {
            var isSuccess = false;
            var @int = 0U;
            
            while (isSuccess == false)
            {
                Console.Write(message);
                var input = Console.ReadLine();
                isSuccess = uint.TryParse(input, out @int) && @int > uint.MinValue;
                
                if(isSuccess == false)
                    Console.WriteLine(errorMessage);
            }

            return @int;
        }

        public static string GetNotEmptyString(string message, string errorMessage, int minLength = 1)
        {
            var isSuccess = false;
            var @string = "";

            while (isSuccess == false)
            {
                Console.Write(message);
                @string = Console.ReadLine();
                isSuccess = string.IsNullOrEmpty(@string) == false && @string.Length >= minLength;
                
                if(isSuccess == false)
                    Console.WriteLine(errorMessage);
            }

            return @string!;
        }
    }
}