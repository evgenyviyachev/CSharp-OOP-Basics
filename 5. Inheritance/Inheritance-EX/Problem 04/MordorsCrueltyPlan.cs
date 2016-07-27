using System;
using System.Text.RegularExpressions;

public class MordorsCrueltyPlan
{
    public static void Main()
    {
        int happiness = 0;

        string pattern = @"[^a-zA-Z]+";
        Regex rgx = new Regex(pattern);
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input))
        {
            Console.WriteLine(happiness);
            Console.WriteLine("Sad");
            return;
        }

        string[] objects = rgx.Replace(input.ToLower(), " ").Trim().Split();

        foreach (var obj in objects)    
        {
            switch (obj)
            {
                case "cram":
                    happiness += 2;
                    break;
                case "lembas":
                    happiness += 3;
                    break;
                case "apple":
                    happiness += 1;
                    break;
                case "melon":
                    happiness += 1;
                    break;
                case "honeycake":
                    happiness += 5;
                    break;
                case "mushrooms":
                    happiness -= 10;
                    break;
                default:
                    happiness -= 1;
                    break;
            }
        }

        Console.WriteLine(happiness);

        if (happiness < -5)
        {
            Console.WriteLine("Angry");
        }
        else if (happiness <= 0)
        {
            Console.WriteLine("Sad");
        }
        else if (happiness <= 15)
        {
            Console.WriteLine("Happy");
        }
        else
        {
            Console.WriteLine("JavaScript");
        }
    }
}