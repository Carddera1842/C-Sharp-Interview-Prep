
//int age = 23;

//bool a = age == 23;

//Console.WriteLine("Age is 23: " + a);

//bool b = age >= 23;
//Console.WriteLine("Age is greater than 23: " + b);

//bool c = (age >= 18) && (age <= 65);
//Console.WriteLine("Age is between 18 and 65: " + c);

//int age1 = 16;
//int age2 = 64;

//bool d = (age1 >= 18) && (age2 <= 65);
//Console.WriteLine("Age1 is greater than 18 AND age2 is less than 65: " + d);

//bool e = (age1 >= 18) || (age2 <= 65);
//Console.WriteLine("Age1 is greater than 18 OR age2 is less than 65: " + e);

Console.WriteLine("Enter the age of the new candidate: ");
int age = int.Parse(Console.ReadLine());

//if (age < 18)
//{
//    Console.WriteLine("Too young to apply");
//    Console.WriteLine("Send email to candidate");
//}
//else if (age > 65)
//{
//    Console.WriteLine("Sorry, the selected age is too old");
//    Console.WriteLine("Send email to candidate");
//}
//else
//{
//    Console.WriteLine("Great, you can start with the application!");
//}


//switch (age)
//{
//    case < 18:
//    case > 65:
//        Console.WriteLine("Sorry, your age is not within the range we are looking for");
//        break;
//    case 23:
//        Console.WriteLine("Wow, exactly what we are looking for");
//    default:
//        Console.WriteLine("Great, you can now start with the application!");
//        break;
//}

//DateTime today = DateTime.Now;
//bool endOfMonthPaymentStarted = false;

//if (today.Date.Day == 20)
//{
//    Console.WriteLine("Please start end-of-month employee payments");
//}
//else if (today.Date.Day >= 25 && !endOfMonthPaymentStarted)
//{
//    Console.WriteLine("Payments will be late!");
//}
//else isn't required!

Console.WriteLine("Choose the action you want to do: ");
Console.WriteLine("1. Add employee");
Console.WriteLine("2. Update employee");
Console.WriteLine("3. Delete employee");
string selectedAction = Console.ReadLine();

switch (selectedAction)
{
    case "1":
        Console.WriteLine("Adding new employee...");
        break;
    case "2":
        Console.WriteLine("Updating employee...");
        break;
    case "3":
        Console.WriteLine("Deleting employee...");
        break;
    default:
        Console.WriteLine("Invalid input");
        break;
}