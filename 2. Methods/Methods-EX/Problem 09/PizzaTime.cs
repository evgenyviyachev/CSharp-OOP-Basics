using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Pizza
{
    public Pizza(string name, int group)
    {
        this.name = name;
        this.group = group;
    }

    private string name;
    private int group;

    public string Name => this.name;
    public int Group => this.group;
}

public class PizzaTime
{
    public static void Main()
    {
        Regex rgx = new Regex(@"(\d+)(\w+)");

        string[] input = Console.ReadLine().Trim().Split().Select(x => x.Trim()).ToArray();
        Match[] matches = new Match[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            Match currentMatch = rgx.Match(input[i]);
            matches[i] = currentMatch;
        }

        var collection = PizzaByGroup(matches);

        foreach (var group in collection)
        {
            Console.WriteLine($"{group.Key} - {string.Join(", ", group.Value)}");
        }
    }

    public static SortedDictionary<int, List<string>> PizzaByGroup(params Match[] pizzaStr)
    {
        SortedDictionary<int, List<string>> collectionOfPizza = new SortedDictionary<int, List<string>>();
        
        for (int i = 0; i < pizzaStr.Length; i++)
        {
            int groupOfPizza = int.Parse(pizzaStr[i].Groups[1].Value);
            string nameOfPizza = pizzaStr[i].Groups[2].Value;

            Pizza currentPizza = new Pizza(nameOfPizza, groupOfPizza);

            if (!collectionOfPizza.ContainsKey(currentPizza.Group))
            {
                collectionOfPizza.Add(currentPizza.Group, new List<string>());
            }

            collectionOfPizza[currentPizza.Group].Add(currentPizza.Name);
        }

        return collectionOfPizza;
    }
}