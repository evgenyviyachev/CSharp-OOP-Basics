using System;
using System.Linq;

public class DateModifier
{
    public DateModifier(int year, int month, int day)
    {
        this.year = year;
        this.month = month;
        this.day = day;
    }

    private int year;
    private int month;
    private int day;

    public double DifferenceDays(DateModifier otherDate)
    {
        DateTime firstDate = new DateTime(this.year, this.month, this.day);
        DateTime secondDate = new DateTime(otherDate.year, otherDate.month, otherDate.day);
        
        double difference = firstDate.Subtract(secondDate).TotalDays;

        return Math.Abs(difference);
    }
}

public class DateModifierProblem
{
    public static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        int[] firstDateParams = firstDate.Trim().Split().Select(int.Parse).ToArray();
        int[] secondDateParams = secondDate.Trim().Split().Select(int.Parse).ToArray();

        DateModifier dateOne = new DateModifier(firstDateParams[0], firstDateParams[1], firstDateParams[2]);
        DateModifier dateTwo = new DateModifier(secondDateParams[0], secondDateParams[1], secondDateParams[2]);

        Console.WriteLine(dateOne.DifferenceDays(dateTwo));
    }
}