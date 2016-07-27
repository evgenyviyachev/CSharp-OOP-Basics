using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private List<Topping> toppings;
    private Dough dough;
    private int numberOfToppings;

    public Pizza(string name, int numberOfToppings)
    {
        this.Name = name;
        this.toppings = new List<Topping>();
        this.NumberOfToppings = numberOfToppings;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public int NumberOfToppings
    {
        get
        {
            return this.numberOfToppings;
        }
        private set
        {
            if (value > 10 || value < 0)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.numberOfToppings = value;
        }
    }

    public double GetTotalCalories()
    {
        double totalCalories = this.dough.Calories;

        for (int i = 0; i < this.NumberOfToppings; i++)
        {
            totalCalories += this.toppings[i].Calories;
        }

        return totalCalories;
    }

    public void AddTopping(Topping topping)
    {
        this.toppings.Add(topping);
    }

    public void SetDough(string flourType, string bakingTechnique, double weight)
    {
        this.dough = new Dough(flourType, bakingTechnique, weight);
    }
}

public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;
    private double calories;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
        this.Calories = calories;
    }

    public string FlourType
    {
        get
        {
            return this.flourType;
        }
        private set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    public string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }
        private set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
        }
    }

    public double Weight
    {
        get
        {
            return this.weight;
        }
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            this.weight = value;
        }
    }

    public double Calories
    {
        get
        {
            return this.calories;
        }
        set
        {
            double a = 0;
            double b = 0;
            switch (this.FlourType.ToLower())
            {
                case "white":
                    a = 1.5;
                    break;
                case "wholegrain":
                    a = 1;
                    break;
                default:
                    break;
            }

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    b = 0.9;
                    break;
                case "chewy":
                    b = 1.1;
                    break;
                case "homemade":
                    b = 1;
                    break;
                default:
                    break;
            }

            this.calories = 2 * a * b * this.Weight;
        }
    }
}

public class Topping
{
    private string type;
    private double weight;
    private double calories;

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
        this.Calories = calories;
    }

    public string Type
    {
        get
        {
            return this.type;
        }
        private set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException("Cannot place " + value + " on top of your pizza.");
            }

            this.type = value;
        }
    }

    public double Weight
    {
        get
        {
            return this.weight;
        }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException(this.Type + " weight should be in the range [1..50].");
            }

            this.weight = value;
        }
    }

    public double Calories
    {
        get
        {
            return this.calories;
        }
        private set
        {
            double modifier = 0;
            switch (this.Type.ToLower())
            {
                case "meat":
                    modifier = 1.2;
                    break;
                case "veggies":
                    modifier = 0.8;
                    break;
                case "cheese":
                    modifier = 1.1;
                    break;
                case "sauce":
                    modifier = 0.9;
                    break;
                default:
                    break;
            }

            this.calories = 2 * modifier * this.Weight;
        }
    }
}

public class PizzaCalories
{
    public static void Main()
    {
        try
        {
            string[] currentData = Console.ReadLine().Split();

            if (currentData[0] != "Pizza")
            {
                if (currentData[0] == "Dough")
                {
                    string flourTypeEx = currentData[1];
                    string bakingTechniqueEx = currentData[2];
                    double weightEx = double.Parse(currentData[3]);
                    Dough currentDough = new Dough(flourTypeEx, bakingTechniqueEx, weightEx);
                    Console.WriteLine($"{currentDough.Calories:F2}");
                }

                string[] currentData2 = Console.ReadLine().Split();

                if (currentData2[0] == "END")
                {
                    return;
                }
                else if (currentData2[0] == "Topping")
                {
                    string typeEX = currentData2[1];
                    double weightOfToppingEX = double.Parse(currentData2[2]);

                    Topping currentTopping = new Topping(typeEX, weightOfToppingEX);
                    Console.WriteLine($"{currentTopping.Calories:F2}");
                    return;
                }
            }
            
            string name = currentData[1];
            int numberOfToppings = int.Parse(currentData[2]);

            Pizza pizza = new Pizza(name, numberOfToppings);

            string[] doughData = Console.ReadLine().Split();

            string flourType = doughData[1];
            string bakingTechnique = doughData[2];
            double weight = double.Parse(doughData[3]);

            //Dough currentDough = new Dough(flourType, bakingTechnique, weight);
            //Console.WriteLine($"{currentDough.Calories:F2}");
            pizza.SetDough(flourType, bakingTechnique, weight);

            string input = Console.ReadLine();

            for (int i = 0; i < numberOfToppings; i++)
            {
                string[] data = input.Split();

                string type = data[1];
                double weightOfTopping = double.Parse(data[2]);

                Topping currentTopping = new Topping(type, weightOfTopping);
                //Console.WriteLine($"{currentTopping.Calories:F2}");
                pizza.AddTopping(currentTopping);

                input = Console.ReadLine();
            }

            Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():F2} Calories.");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}