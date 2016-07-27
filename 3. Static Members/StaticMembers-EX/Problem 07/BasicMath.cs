using System;

public class MathUtil
{
    public static void Sum(double a, double b)
    {
        double sum = a + b;
        Console.WriteLine($"{sum:F2}");
    }

    public static void Subtract(double a, double b)
    {
        double difference = a - b;
        Console.WriteLine($"{difference:F2}");
    }

    public static void Multiply(double a, double b)
    {
        double product = a * b;
        Console.WriteLine($"{product:F2}");
    }

    public static void Divide(double a, double b)
    {
        double result = a / b;
        Console.WriteLine($"{result:F2}");
    }

    public static void Percentage(double num, double percent)
    {
        double percentage = (percent / 100) * num;
        Console.WriteLine($"{percentage:F2}");
    }
}

public class BasicMath
{
    public static void Main()
    {
        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] data = input.Trim().Split();
            double a = double.Parse(data[1]);
            double b = double.Parse(data[2]);

            switch (data[0])
            {
                case "Sum":
                    MathUtil.Sum(a, b);
                    break;
                case "Subtract":
                    MathUtil.Subtract(a, b);
                    break;
                case "Multiply":
                    MathUtil.Multiply(a, b);
                    break;
                case "Divide":
                    MathUtil.Divide(a, b);
                    break;
                case "Percentage":
                    MathUtil.Percentage(a, b);
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }
    }
}