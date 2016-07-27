using System;

public abstract class Food
{
    public int Quantity { get; set; }
}

public class Vegetable : Food
{
}

public class Meat : Food
{
}

public abstract class Animal
{
    public string AnimalName { get; set; }
    public string AnimalType { get; set; }
    public double AnimalWeight { get; set; }
    public int FoodEaten { get; set; }

    public abstract void MakeSound();
    public abstract void Eat(Food food);
}

public abstract class Mammal : Animal
{
    public string LivingRegion { get; set; }

    public override string ToString()
    {
        return $"{this.GetType().Name}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

public abstract class Felime : Mammal
{
}

public class Cat : Felime
{
    public string Breed { get; set; }

    public override void MakeSound()
    {
        Console.WriteLine("Meowwww");
    }

    public override void Eat(Food food)
    {
        this.FoodEaten += food.Quantity;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}[{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

public class Tiger : Felime
{
    public override void MakeSound()
    {
        Console.WriteLine("ROAAR!!!");
    }

    public override void Eat(Food food)
    {
        if (food is Vegetable)
        {
            Console.WriteLine("Tigers are not eating that type of food!");
            return;
        }

        this.FoodEaten += food.Quantity;
    }
}

public class Mouse : Mammal
{
    public override void MakeSound()
    {
        Console.WriteLine("SQUEEEAAAK!");
    }

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            Console.WriteLine("Mouses are not eating that type of food!");
            return;
        }

        this.FoodEaten += food.Quantity;
    }
}

public class Zebra : Mammal
{
    public override void MakeSound()
    {
        Console.WriteLine("Zs");
    }

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            Console.WriteLine("Zebras are not eating that type of food!");
            return;
        }

        this.FoodEaten += food.Quantity;
    }
}

public class WildFarm
{
    public static void Main()
    {
        string firstLine = Console.ReadLine();

        while (firstLine != "End")
        {
            string[] animalInfo = firstLine.Split();
            string secondLine = Console.ReadLine();
            string[] foodInfo = secondLine.Split();

            Animal animal;
            Food food;

            if (foodInfo[0] == "Vegetable")
            {
                food = new Vegetable { Quantity = int.Parse(foodInfo[1]) };
            }
            else
            {
                food = new Meat { Quantity = int.Parse(foodInfo[1]) };
            }

            switch (animalInfo[0])
            {
                case "Cat":
                    animal = new Cat
                    {
                        AnimalType = animalInfo[0],
                        AnimalName = animalInfo[1],
                        AnimalWeight = double.Parse(animalInfo[2]),
                        LivingRegion = animalInfo[3],
                        Breed = animalInfo[4]
                    };

                    animal.MakeSound();
                    animal.Eat(food);
                    Console.WriteLine(animal);
                    break;

                case "Tiger":
                    animal = new Tiger
                    {
                        AnimalType = animalInfo[0],
                        AnimalName = animalInfo[1],
                        AnimalWeight = double.Parse(animalInfo[2]),
                        LivingRegion = animalInfo[3]
                    };
                    
                    animal.MakeSound();
                    animal.Eat(food);
                    Console.WriteLine(animal);
                    break;

                case "Zebra":
                    animal = new Zebra
                    {
                        AnimalType = animalInfo[0],
                        AnimalName = animalInfo[1],
                        AnimalWeight = double.Parse(animalInfo[2]),
                        LivingRegion = animalInfo[3]
                    };

                    animal.MakeSound();
                    animal.Eat(food);
                    Console.WriteLine(animal);
                    break;

                case "Mouse":
                    animal = new Mouse
                    {
                        AnimalType = animalInfo[0],
                        AnimalName = animalInfo[1],
                        AnimalWeight = double.Parse(animalInfo[2]),
                        LivingRegion = animalInfo[3]
                    };

                    animal.MakeSound();
                    animal.Eat(food);
                    Console.WriteLine(animal);
                    break;

                default:
                    break;
            }

            firstLine = Console.ReadLine();
        }
    }
}