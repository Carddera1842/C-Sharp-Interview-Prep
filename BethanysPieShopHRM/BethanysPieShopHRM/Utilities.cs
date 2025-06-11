using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM
{
    internal class Utilities
    {

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
