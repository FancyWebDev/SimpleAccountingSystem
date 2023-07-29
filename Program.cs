using SimpleEmployeeAccountingSystem;

var employeeManagement = new EmployeeManagement();

employeeManagement.AddEmployee("Alex", 24, "TeamLead");
employeeManagement.AddEmployee("Sam", 21, "Programmer");
employeeManagement.AddEmployee("Jhon", 26, "Designer");

var app = new App(employeeManagement);

app.Start();