using System.Collections.Generic;

namespace SimpleEmployeeAccountingSystem
{
    
    public class EmployeeManagement
    {
        private readonly Dictionary<int, Employee> _employees = new();
        private static int _idIncrement;

        public void AddEmployee(string name, int age, string post)
        {
            var id = ++_idIncrement;
            _employees.Add(id, new Employee(id, name, age, post));
        }

        public bool Contains(int id) => _employees.ContainsKey(id);

        public bool GetEmployee(int id, out Employee employee) => _employees.TryGetValue(id, out employee!);
        
        public bool RemoveEmployee(int id) => _employees.Remove(id);

        public void UpdateEmployee(Employee updatedEmployee) => _employees[updatedEmployee.Id] = updatedEmployee;

        public IEnumerable<Employee> GetAllEmployees() => _employees.Values;
    }
}