using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public Person(string name)
    {
        this.name = name;
        this.job = new Job();
        this.pokemons = new List<Pokemon>();
        this.parents = new List<Parent>();
        this.children = new List<Child>();
        this.car = new Car();
    }

    public string name;
    public Job job;
    public List<Pokemon> pokemons;
    public List<Parent> parents;
    public List<Child> children;
    public Car car;
}

public class Job
{
    public Job()
    {
        this.companyName = string.Empty;
        this.department = string.Empty;
    }

    public string companyName;
    public string department;
    public decimal salary;
}

public class Pokemon
{
    public Pokemon()
    {
        this.pokemonName = string.Empty;
        this.pokemonType = string.Empty;
    }

    public string pokemonName;
    public string pokemonType;
}

public class Parent
{
    public Parent()
    {
        this.parentName = string.Empty;
        this.parentBirthday = string.Empty;
    }

    public string parentName;
    public string parentBirthday;
}

public class Child
{
    public Child()
    {
        this.childName = string.Empty;
        this.childBirthday = string.Empty;
    }

    public string childName;
    public string childBirthday;
}

public class Car
{
    public Car()
    {
        this.carModel = string.Empty;
    }

    public string carModel;
    public int carSpeed;
}

public class Google
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<Person> people = new List<Person>();

        while (input != "End")
        {
            string[] currentData = input.Trim().Split();
            string name = currentData[0];

            if (!people.Any(p => p.name == name))
            {
                Person newPerson = new Person(name);
                switch (currentData[1])
                {
                    case "company":
                        string companyName = currentData[2];
                        string department = currentData[3];
                        decimal salary = decimal.Parse(currentData[4]);
                        newPerson.job.companyName = companyName;
                        newPerson.job.department = department;
                        newPerson.job.salary = salary;
                        break;
                    case "pokemon":
                        string pokemonName = currentData[2];
                        string pokemonType = currentData[3];
                        Pokemon newPokemon = new Pokemon();
                        newPokemon.pokemonName = pokemonName;
                        newPokemon.pokemonType = pokemonType;
                        newPerson.pokemons.Add(newPokemon);
                        break;
                    case "parents":
                        string parentName = currentData[2];
                        string parentBirthday = currentData[3];
                        Parent newParent = new Parent();
                        newParent.parentName = parentName;
                        newParent.parentBirthday = parentBirthday;
                        newPerson.parents.Add(newParent);
                        break;
                    case "children":
                        string childName = currentData[2];
                        string childBirthday = currentData[3];
                        Child newChild = new Child();
                        newChild.childName = childName;
                        newChild.childBirthday = childBirthday;
                        newPerson.children.Add(newChild);
                        break;
                    case "car":
                        string carModel = currentData[2];
                        int carSpeed = int.Parse(currentData[3]);
                        newPerson.car.carModel = carModel;
                        newPerson.car.carSpeed = carSpeed;
                        break;
                    default:
                        break;
                }

                people.Add(newPerson);
            }
            else
            {
                Person currentPerson = people.First(p => p.name == name);
                switch (currentData[1])
                {
                    case "company":
                        string companyName = currentData[2];
                        string department = currentData[3];
                        decimal salary = decimal.Parse(currentData[4]);
                        currentPerson.job.companyName = companyName;
                        currentPerson.job.department = department;
                        currentPerson.job.salary = salary;
                        break;
                    case "pokemon":
                        string pokemonName = currentData[2];
                        string pokemonType = currentData[3];
                        Pokemon newPokemon = new Pokemon();
                        newPokemon.pokemonName = pokemonName;
                        newPokemon.pokemonType = pokemonType;
                        currentPerson.pokemons.Add(newPokemon);
                        break;
                    case "parents":
                        string parentName = currentData[2];
                        string parentBirthday = currentData[3];
                        Parent newParent = new Parent();
                        newParent.parentName = parentName;
                        newParent.parentBirthday = parentBirthday;
                        currentPerson.parents.Add(newParent);
                        break;
                    case "children":
                        string childName = currentData[2];
                        string childBirthday = currentData[3];
                        Child newChild = new Child();
                        newChild.childName = childName;
                        newChild.childBirthday = childBirthday;
                        currentPerson.children.Add(newChild);
                        break;
                    case "car":
                        string carModel = currentData[2];
                        int carSpeed = int.Parse(currentData[3]);
                        currentPerson.car.carModel = carModel;
                        currentPerson.car.carSpeed = carSpeed;
                        break;
                    default:
                        break;
                }
            }

            input = Console.ReadLine();
        }

        string nameOfPersonToView = Console.ReadLine();

        var personToView = people.First(p => p.name == nameOfPersonToView);
        
        Console.WriteLine(personToView.name);
        Console.WriteLine("Company:");
        if (personToView.job.companyName != string.Empty)
        {
            Console.WriteLine($"{personToView.job.companyName} {personToView.job.department} {personToView.job.salary:F2}");
        }
        Console.WriteLine("Car:");
        if (personToView.car.carModel != string.Empty)
        {
            Console.WriteLine(personToView.car.carModel + " " + personToView.car.carSpeed);
        }
        Console.WriteLine("Pokemon:");
        if (personToView.pokemons.Count > 0)
        {
            foreach (var pokemon in personToView.pokemons)
            {
                Console.WriteLine(pokemon.pokemonName + " " + pokemon.pokemonType);
            }
        }
        Console.WriteLine("Parents:");
        if (personToView.parents.Count > 0)
        {
            foreach (var parent in personToView.parents)
            {
                Console.WriteLine(parent.parentName + " " + parent.parentBirthday);
            }
        }
        Console.WriteLine("Children:");
        if (personToView.children.Count > 0)
        {
            foreach (var child in personToView.children)
            {
                Console.WriteLine(child.childName + " " + child.childBirthday);
            }
        }
    }
}