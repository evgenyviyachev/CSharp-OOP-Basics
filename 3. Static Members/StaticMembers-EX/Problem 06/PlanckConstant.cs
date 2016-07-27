using System;

public class Calculation
{
    public const double planckConst = 6.62606896e-34;
    public const double pi = 3.14159;

    public static void ReturnReduced()
    {
        Console.WriteLine(planckConst / (2 * pi));
    }
}

public class PlanckConstant
{
    public static void Main()
    {
        Calculation.ReturnReduced();
    }
}