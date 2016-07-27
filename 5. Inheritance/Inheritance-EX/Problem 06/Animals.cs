using System;
using System.Text;

public class Animal
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        protected set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.name = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        protected set
        {
            if (string.IsNullOrEmpty(value.ToString())
                || string.IsNullOrWhiteSpace(value.ToString())
                || value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }

            this.age = value;
        }
    }

    public string Gender
    {
        get
        {
            return this.gender;
        }
        protected set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            if (value.ToLower() != "male" && value.ToLower() != "female")
            {
                throw new ArgumentException("Invalid input!");
            }

            this.gender = value;
        }
    }

    public virtual void ProduceSound()
    {
        Console.WriteLine("Not implemented!");
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(this.GetType()).Append(Environment.NewLine)
            .Append(this.Name).Append(" ")
            .Append(this.Age).Append(" ")
            .Append(this.Gender);

        return sb.ToString();
    }
}

public class Dog : Animal
{
    public Dog(string name, int age, string gender)
        : base(name, age, gender)
    {

    }

    public override void ProduceSound()
    {
        Console.WriteLine("BauBau");
    }
}

public class Frog : Animal
{
    public Frog(string name, int age, string gender)
        : base(name, age, gender)
    {

    }

    public override void ProduceSound()
    {
        Console.WriteLine("Frogggg");
    }
}

public class Cat : Animal
{
    public Cat(string name, int age, string gender)
        : base(name, age, gender)
    {

    }

    public override void ProduceSound()
    {
        Console.WriteLine("MiauMiau");
    }
}

public class Tomcat : Cat
{
    public Tomcat(string name, int age, string gender)
        : base(name, age, gender)
    {
        this.Gender = "Male";
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Give me one million b***h");
    }
}

public class Kitten : Cat
{
    public Kitten(string name, int age, string gender)
        : base(name, age, gender)
    {
        this.Gender = "Female";
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Miau");
    }
}

public class Animals
{
    public static void Main()
    {
        string input = Console.ReadLine();

        try
        {
            while (input != "Beast!")
            {
                string type = input;
                input = Console.ReadLine();
                string[] data = input.Split();
                string name = null;
                int age = -1;
                string gender = null;

                try
                {
                    name = data[0];
                    age = int.Parse(data[1]);
                    gender = data[2];
                }
                catch (Exception)
                {                    
                }

                switch (type.ToLower())
                {
                    case "cat":
                        Cat cat = new Cat(name, age, gender);
                        Console.WriteLine(cat);
                        cat.ProduceSound();
                        break;
                    case "dog":
                        Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(dog);
                        dog.ProduceSound();
                        break;
                    case "frog":
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(frog);
                        frog.ProduceSound();
                        break;
                    case "tomcat":
                        Tomcat tomcat = new Tomcat(name, age, "Male");
                        Console.WriteLine(tomcat);
                        tomcat.ProduceSound();
                        break;
                    case "kitten":
                        Kitten kitten = new Kitten(name, age, "Female");
                        Console.WriteLine(kitten);
                        kitten.ProduceSound();
                        break;
                    case "animal":
                        Animal animal = new Animal(name, age, gender);
                        Console.WriteLine(animal);
                        animal.ProduceSound();
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}