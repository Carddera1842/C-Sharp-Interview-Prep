using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM
{
    internal class Utilities
    {

        public static int CalculateYearlyWage(int monthlyWage, int numberOfMOnthsWorked)
        {
            //Console.WriteLine($"Yearly wage: {monthlyWage * numberOfMOnthsWorked}");
            //return monthlyWage * numberOfMOnthsWorked;

            if (numberOfMOnthsWorked == 12) //let's add a bonus month
                return monthlyWage * (numberOfMOnthsWorked + 1);

            return monthlyWage * numberOfMOnthsWorked;
        }

        public static int CalculateYearlyWage(int monthlyWage, int numberOfMOnthsWorked, int bonus)
        {
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
