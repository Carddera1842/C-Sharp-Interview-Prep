using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM
{
    internal class Utilities
    {

        public static void UsingStringEquality()
        {
            string name1 = "Bethany";
            string name2 = "BETHANY";

            Console.WriteLine("Are both names equal? " + (name1 == name2));
            Console.WriteLine("Is name equal to Bethany? " + (name1 == "Bethany"));
            Console.WriteLine("Is name equal to BETHANY? " + name2.Equals("BETHANY"));
            Console.WriteLine("Is lowercase name equal to bethany? " + (name1.ToLower() == "bethany"));
        }

        public static void UsingEscapeCharcters()
        {
            string firstName = "Bethany";
            string lastName = "Smith";

            string displayName = $"Welcome!\n{firstName}\t{lastName}";
            Console.WriteLine(displayName);

            string filePath = @"C:\data\employeelist.xlsx";
            string marketingTagLine = "Baking the \"best pies\" ever";
        }

        public static void ManipulatingStrings()
        {
            string firstName = "Bethany";
            string lastName = "Smith";

            string fullName = firstName + " " + lastName;
            string employeeIdentification = String.Concat(firstName, lastName);
        
            string empId = firstName.ToLower() + " " + lastName.Trim().ToLower();

            int length = empId.Length;

            if (fullName.Contains("beth") || fullName.Contains("Beth"))
            {
                Console.WriteLine("It's Bethany!");
            }

            string subString = fullName.Substring(1, 3);
            Console.WriteLine("Characters 2 to 4 of fullName are " + subString);

            string userNameWithInterpolation = $"{firstName}-{lastName}";
        }

        public static void UsingSimpleStrings()
        {
            string firstName = "Bethany";
            string lastName = "Smith";
            string s;
            s = firstName;
            var userName = "BethanyS";
            userName = userName.ToLower();

            userName = "";  //identical to string.Empty
        }

        public static void UsingExpressionBodiedSyntax()
        {
            int amount = 1234;
            int months = 12;
            int bonus = 500;

            int yearlyWageForEmployee1 = CalculateYearlyWageExpressionBodied(amount, 
                months, bonus);
            Console.WriteLine($"Yearly wage for employee 1 (Bethany): {yearlyWageForEmployee1}");
        }

        public static int CalculateYearlyWageExpressionBodied(int monthlyWage, int numberOfMonthsWorked, int bonus) =>
            monthlyWage * numberOfMonthsWorked + bonus;

        public static void UsingNamedArguments()
        {
            int amount = 1234;
            int months = 12;
            int bonus = 500;

            int yearlyWageForEmployee = CalculateYearlyWageWithNamed(bonus: bonus, monthlyWage: amount, numberOfMonthsWorked: months);
        }

        public static int CalculateYearlyWageWithNamed(int monthlyWage, int numberOfMonthsWorked, int bonus)
        {
            Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMonthsWorked + bonus}");
            return monthlyWage * numberOfMonthsWorked + bonus;
        }

        public static void UsingOptionalParamenters()
        {
            int monthlyWage1 = 1234;
            int months1 = 12;
            int yearlyWageForEmployee1 = CalculateYearlyWageWithOptional(monthlyWage1, months1);
            Console.WriteLine($"Yearly wage for employee 1 (Bethany): {yearlyWageForEmployee1}");
        }

        public static int CalculateYearlyWageWithOptional(int monthlyWage, int numberOfMonthsWorked, int bonus = 0)
        {
            Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMonthsWorked + bonus}");
            return monthlyWage * numberOfMonthsWorked + bonus;
        }

        public static int CalculateYearlyWage(int monthlyWage, int numberOfMOnthsWorked)
        {
            int local = 100;
            //Console.WriteLine($"Yearly wage: {monthlyWage * numberOfMOnthsWorked}");
            //return monthlyWage * numberOfMOnthsWorked;

            if (numberOfMOnthsWorked == 12) //let's add a bonus month
                return monthlyWage * (numberOfMOnthsWorked + 1);

            return monthlyWage * numberOfMOnthsWorked;
        }

        public static int CalculateYearlyWage(int monthlyWage, int numberOfMOnthsWorked, int bonus)
        {
            int local = 150;
            Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMOnthsWorked + bonus}");

            return monthlyWage * numberOfMOnthsWorked + bonus;
        }

        public static double CalculateYearlyWage(double monthlyWage, double numberOfMOnthsWorked, double bonus)
        {
            Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMOnthsWorked + bonus}");

            return monthlyWage * numberOfMOnthsWorked + bonus;
        }

    }
}
