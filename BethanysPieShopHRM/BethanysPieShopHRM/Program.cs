

using BethanysPieShopHRM;
using System.Text;

Console.WriteLine("Creating an employee");
Console.WriteLine("----------------------\n");

Employee bethany = new Employee("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25, EmployeeType.Manager);

Employee george = new Employee("George", "Jones", "george@snowball.be", new DateTime(1984, 3, 28), 30, EmployeeType.Research);

Console.WriteLine("Creating an employee");
Console.WriteLine("----------------------\n");

bethany.DisplayEmployeeDetails();

bethany.PerformWork();
bethany.PerformWork();
bethany.PerformWork(5);
bethany.PerformWork();

bethany.firstName = "John";
bethany.hourlyRate = 10;

double recieveWageBethany = bethany.ReceiveWage(true);
Console.WriteLine($"Wage paid (message from Program): {recieveWageBethany}");


george.DisplayEmployeeDetails();

george.PerformWork();
george.PerformWork();
george.PerformWork(3);
george.PerformWork();
george.PerformWork(8);

double recieveWageGeorge = george.ReceiveWage(true);
Console.WriteLine($"Wage paid (message from Program): {recieveWageGeorge}");

WorkTask task;
task.description = "Bake delicious pies";
task.hours = 3;
task.PerformWorkTask();
