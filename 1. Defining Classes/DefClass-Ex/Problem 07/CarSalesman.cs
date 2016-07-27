using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.weight = Constants.MissingInfo;
        this.color = Constants.MissingInfo;
    }

    public string model;
    public Engine engine;
    public string weight;
    public string color;

    public override string ToString()
    {
        string result = $"{this.model}:\n  {this.engine.model}:\n    Power: {this.engine.power}\n    Displacement: {this.engine.displacements}\n    Efficiency: {this.engine.efficiency}\n  Weight: {this.weight}\n  Color: {this.color}";
        return result;
    }
}

public class Engine
{
    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
        this.displacements = Constants.MissingInfo;
        this.efficiency = Constants.MissingInfo;
    }

    public string model;
    public int power;
    public string displacements;
    public string efficiency;
}

public static class Constants
{
    public const string MissingInfo = @"n/a";
}

public class CarSalesman
{
    public static void Main()
    {
        int engineNum = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < engineNum; i++)
        {
            string[] engineFeatures = Console.ReadLine().Trim().Split();

            string model = engineFeatures[0];
            int power = int.Parse(engineFeatures[1]);

            Engine currentEngine = new Engine(model, power);

            if (engineFeatures.Length == 4)
            {
                string displacements = engineFeatures[2];
                string efficiency = engineFeatures[3];
                currentEngine.displacements = displacements;
                currentEngine.efficiency = efficiency;
            }
            else if (engineFeatures.Length == 3)
            {
                int num;
                bool isNumeric = int.TryParse(engineFeatures[2], out num);

                if (!isNumeric)
                {
                    currentEngine.efficiency = engineFeatures[2];
                }
                else
                {
                    currentEngine.displacements = num.ToString();
                }
            }

            engines.Add(currentEngine);
        }

        int carsCount = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < carsCount; i++)
        {
            string[] carFeatures = Console.ReadLine().Trim().Split();

            string model = carFeatures[0];
            string engineModel = carFeatures[1];
            Engine currentCarEngine = engines.FirstOrDefault(x => x.model == engineModel);

            Car currentCar = new Car(model, currentCarEngine);

            if (carFeatures.Length == 4)
            {
                string weight = carFeatures[2];
                string color = carFeatures[3];
                currentCar.weight = weight;
                currentCar.color = color;
            }
            else if (carFeatures.Length == 3)
            {
                int num;
                bool isNumeric = int.TryParse(carFeatures[2], out num);

                if (!isNumeric)
                {
                    currentCar.color = carFeatures[2];
                }
                else
                {
                    currentCar.weight = num.ToString();
                }
            }

            cars.Add(currentCar);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}