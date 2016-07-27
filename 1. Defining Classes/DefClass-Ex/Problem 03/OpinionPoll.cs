using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string name;
    public int age;
}

public class OpinionPoll
{
    public static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int i = 0; i < numberOfLines; i++)
        {
            string[] currentPersonInfo = Console.ReadLine().Trim().Split();
            people.Add(new Person
            {
                name = currentPersonInfo[0],
                age = int.Parse(currentPersonInfo[1])
            });
        }

        var sortedFilteredPeople = people
            .Where(x => x.age > 30)
            .OrderBy(x => x.name)
            .ToList();

        foreach (var person in sortedFilteredPeople)
        {
            Console.WriteLine($"{person.name} - {person.age}");
        }
    }
}