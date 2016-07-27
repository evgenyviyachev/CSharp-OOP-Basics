using System;
using System.Text;

public class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    protected virtual string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value.Length < 3 || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }

            this.name = value;
        }
    }

    protected virtual int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }

            this.age = value;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(string.Format("Name: {0}, Age: {1}",
                             this.Name,
                             this.Age));

        return stringBuilder.ToString();
    }
}

public class Child : Person
{
    public Child(string name, int age)
        : base(name, age)
    {
        this.Age = age;
    }

    protected override int Age
    {
        get
        {
            return base.Age;
        }
        set
        {
            if (value >= 15)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }

            base.Age = value;
        }
    }
}

public class PersonProblem
{
    public static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        try
        {
            Child child = new Child(name, age);
            Console.WriteLine(child);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }

    }
}