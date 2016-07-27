using System;
using System.Collections.Generic;

public class Animal
{
    public string name;
    public string breed;

    public Animal(string name, string breed)
    {
        this.name = name;
        this.breed = breed;
        AnimalClinic.patientID++;
    }
}

public class AnimalClinic
{
    public static int patientID;
    public static int healedAnimalsCount;
    public static int rehabilitatedAnimalsCount;
}

public class AnimalClinicProblem
{
    public static void Main()
    {
        List<Animal> healedAnimals = new List<Animal>();
        List<Animal> rehabilitatedAnimals = new List<Animal>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] currentData = input.Trim().Split();
            string name = currentData[0];
            string breed = currentData[1];
            string command = currentData[2];

            Animal currentAnimal = new Animal(name, breed);

            if (command == "heal")
            {
                AnimalClinic.healedAnimalsCount++;
                healedAnimals.Add(currentAnimal);
                Console.WriteLine($"Patient {AnimalClinic.patientID}: [{currentAnimal.name} ({currentAnimal.breed})] has been healed!");
            }
            else
            {
                AnimalClinic.rehabilitatedAnimalsCount++;
                rehabilitatedAnimals.Add(currentAnimal);
                Console.WriteLine($"Patient {AnimalClinic.patientID}: [{currentAnimal.name} ({currentAnimal.breed})] has been rehabilitated!");
            }

            input = Console.ReadLine();
        }

        Console.WriteLine($"Total healed animals: {healedAnimals.Count}");
        Console.WriteLine($"Total rehabilitated animals: {rehabilitatedAnimals.Count}");

        input = Console.ReadLine();

        if (input == "heal")
        {
            foreach (var animal in healedAnimals)
            {
                Console.WriteLine($"{animal.name} {animal.breed}");
            }
        }
        else
        {
            foreach (var animal in rehabilitatedAnimals)
            {
                Console.WriteLine($"{animal.name} {animal.breed}");
            }
        }
    }
}