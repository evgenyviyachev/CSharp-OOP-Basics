using System;
using System.Collections.Generic;

public class Person
{
    public Person(string name, int age, string occupation)
    {
        this.name = name;
        this.age = age;
        this.occupation = occupation;
    }

    private string name;
    private int age;
    private string occupation;

    public override string ToString()
    {
        return $"{this.name} - age: {this.age}, occupation: {this.occupation}";
    }

    public int CompareTo(Person otherPerson)
    {
        if (this.age > otherPerson.age)
        {
            return 1;
        }
        else if (this.age < otherPerson.age)
        {
            return -1;
        }

        return 0;
    }
}

public class PrintPeople
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<Person> people = new List<Person>();

        while (input != "END")
        {
            string[] currentData = input.Split();
            string name = currentData[0];
            int age = int.Parse(currentData[1]);
            string occupation = currentData[2];

            Person currentPerson = new Person(name, age, occupation);
            people.Add(currentPerson);

            input = Console.ReadLine();
        }

        people.Sort((x, y) => x.CompareTo(y));

        foreach (var person in people)
        {
            Console.WriteLine(person.ToString());
        }
    }
}