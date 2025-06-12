using BethanysPieShopHRM.Accounting;
using BethanysPieShopHRM.HR;
using System.Text;

Console.WriteLine("Creating an employee");
Console.WriteLine("----------------------\n");

Employee bethany = new Employee("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25, EmployeeType.Manager);


Console.WriteLine("Creating an employee");
Console.WriteLine("----------------------\n");

Employee george = new Employee("George", "Jones", "george@snowball.be", new DateTime(1984, 3, 28), null, EmployeeType.Research);

int[] sampleArray1 = new int[5];

int[] sampleArray2 = new int[] { 1, 2, 3, 4, 5 };

//int[] sampleArray3 = new int[5] { 1, 2, 3, 4, 5, 6 };

Console.WriteLine("How many employee IDs do you want to register?");

int length = int.Parse(Console.ReadLine());

int[] employeeIds = new int[length];

var testId = employeeIds[0];
//var errorId = employeeIds[length];

for (int i = 0; i < length; i++)
{
    Console.WriteLine("Enter the employee ID: ");
    int id = int.Parse(Console.ReadLine()); //let's assume here that the user will always enter an int value
    employeeIds[i] = id;
}


for (int i = 0; i < employeeIds.Length; ++i)
{
    Console.WriteLine($"ID {i + 1}: \t{employeeIds[i]}");
}