

int amount = 1234;
int months = 12;

int yearlyWage = CalculateYearlyWage(amount, months);

Console.WriteLine($"Yearly wage: {yearlyWage}");

Console.ReadLine();

static int CalculateYearlyWage(int monthlyWage, int numberOfMOnthsWorked)
{
    //Console.WriteLine($"Yearly wage: {monthlyWage * numberOfMOnthsWorked}");
    //return monthlyWage * numberOfMOnthsWorked;

    if (numberOfMOnthsWorked == 12) //let's add a bonus month
        return monthlyWage * (numberOfMOnthsWorked + 1);

    return monthlyWage * numberOfMOnthsWorked;
}