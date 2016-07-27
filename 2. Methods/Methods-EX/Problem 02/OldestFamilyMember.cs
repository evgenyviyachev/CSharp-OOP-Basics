using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Person
{
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public string name;
    public int age;
}

public class Family
{
    public Family()
    {
        this.familyMembers = new List<Person>();
    }

    public List<Person> familyMembers;

    public void AddMember(Person person)
    {
        this.familyMembers.Add(person);
    }

    public Person GetOldestMember()
    {
        var oldestMember = this.familyMembers.OrderByDescending(x => x.age).First();
        return oldestMember;
    }
}

public class OldestFamilyMember
{
    public static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        Family family = new Family();

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string[] currentPerson = Console.ReadLine().Trim().Split();
            string name = currentPerson[0];
            int age = int.Parse(currentPerson[1]);

            family.AddMember(new Person(name, age));
        }

        var oldestPerson = family.GetOldestMember();

        Console.WriteLine($"{oldestPerson.name} {oldestPerson.age}");
    }
}