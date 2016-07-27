using System;

public class TemperatureConverter
{
    public static void Main()
    {
        string input = Console.ReadLine();

        while (input != "End")
        {
            ConvertTemperature(input);
            input = Console.ReadLine();
        }
    }

    public static void ConvertTemperature(string input)
    {
        string[] data = input.Trim().Split();
        int grades = int.Parse(data[0]);
        string typeFrom = data[1];

        double newValue;
        string newScale = string.Empty;

        if (typeFrom == "Celsius")
        {
            newValue = (double)grades * 9 / 5 + 32;
            newScale = "Fahrenheit";
        }
        else
        {
            newValue = (double)(grades - 32) * 5 / 9;
            newScale = "Celsius";
        }

        Console.WriteLine($"{newValue:F2} {newScale}");
    }
}