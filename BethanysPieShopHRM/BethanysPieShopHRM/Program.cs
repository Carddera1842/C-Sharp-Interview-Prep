using BethanysPieShopHRM.Accounting;
using BethanysPieShopHRM.HR;
using System.Text;

Console.WriteLine("Creating an employee");
Console.WriteLine("----------------------\n");

Employee bethany = new Employee("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25, EmployeeType.Manager);


Console.WriteLine("Creating an employee");
Console.WriteLine("----------------------\n");

Employee george = new Employee("George", "Jones", "george@snowball.be", new DateTime(1984, 3, 28), null, EmployeeType.Research);

Employee.DisplayTaxRate();

double calculatedWage = bethany.CalculateWage();
Console.WriteLine($"The estimated wage is {calculatedWage}.");

Account account = new Account("123456789");
account.AccountNumber = "987654321";

