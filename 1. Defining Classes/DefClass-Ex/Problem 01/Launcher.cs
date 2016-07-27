using System;
using System.Reflection;

class Person
{
    public string name;
    public int age;
}

class Launcher
{
    static void Main()
    {
        Type personType = typeof(Person);
        FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine(fields.Length);

        Person firstPerson = new Person
        {
            name = "Pesho",
            age = 20
        };

        var secondPerson = new Person
        {
            name = "Gosho",
            age = 18
        };

        var thirdPerson = new Person();
        thirdPerson.name = "Stamat";
        thirdPerson.age = 43;
    }
}