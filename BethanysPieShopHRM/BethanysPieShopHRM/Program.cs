

using BethanysPieShopHRM;

//int a = 42;
//int aCopy = a;
//Console.WriteLine($"Value of a: {a} and value of a copy of a: {aCopy}");
//aCopy = 100;
//Console.WriteLine($"Value of a: {a} and value of a copy of a: {aCopy}");

Console.WriteLine("Creating an employee");
Console.WriteLine("----------------------\n");

Employee bethany = new Employee("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25);

Employee testEmployee = bethany;
testEmployee.firstName = "Gill";

testEmployee.DisplayEmployeeDetails();
bethany.DisplayEmployeeDetails();

//bethany.DisplayEmployeeDetails();

//bethany.PerformWork();
//bethany.PerformWork();
//bethany.PerformWork(5);
//bethany.PerformWork();

//bethany.firstName = "John";
//bethany.hourlyRate = 10;

//bethany.DisplayEmployeeDetails();

//bethany.PerformWork();
//bethany.PerformWork(12);
//bethany.PerformWork();
//bethany.PerformWork();

//string fn = bethany.firstName;

//double recieveWageBethany = bethany.ReceiveWage(true);
//Console.WriteLine($"Wage paid (message from Program): {recieveWageBethany}");

//Console.WriteLine("Creating an employee");
//Console.WriteLine("----------------------\n");

//Employee george = new Employee("George", "Jones", "george@snowball.be", new DateTime(1984, 3, 28), 30);

//george.DisplayEmployeeDetails();

//george.PerformWork();
//george.PerformWork();
//george.PerformWork(3);
//george.PerformWork();
//george.PerformWork(8);

//double recieveWageGeorge = george.ReceiveWage(true);
//Console.WriteLine($"Wage paid (message from Program): {recieveWageGeorge}");