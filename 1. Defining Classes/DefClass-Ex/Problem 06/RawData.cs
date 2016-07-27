using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType,
        int tire1Age, double tire1Pressure, int tire2Age, double tire2Pressure,
        int tire3Age, double tire3Pressure, int tire4Age, double tire4Pressure)
    {
        this.model = model;
        this.engine = new Engine();
        this.engine.power = enginePower;
        this.engine.speed = engineSpeed;
        this.cargo = new Cargo();
        this.cargo.weight = cargoWeight;
        this.cargo.type = cargoType;
        this.tires = new Tire[4];
        int[] tiresAge = new[] { tire1Age, tire2Age, tire3Age, tire4Age };
        double[] tiresPressure = new[] { tire1Pressure, tire2Pressure, tire3Pressure, tire4Pressure };
        for (int i = 0; i < 4; i++)
        {
            this.tires[i] = new Tire();
            this.tires[i].age = tiresAge[i];
            this.tires[i].pressure = tiresPressure[i];
        }
    }

    public string model;
    public Engine engine;
    public Cargo cargo;
    public Tire[] tires;
}

public class Engine
{
    public int speed;
    public int power;
}

public class Cargo
{
    public int weight;
    public string type;
}

public class Tire
{
    public int age;
    public double pressure;
}

public class RawData
{
    public static void Main()
    {
        List<Car> cars = new List<Car>();
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string[] data = Console.ReadLine().Trim().Split();

            Car currentCar = new Car(data[0], int.Parse(data[1]), int.Parse(data[2]),
                int.Parse(data[3]), data[4], int.Parse(data[6]), double.Parse(data[5]),
                int.Parse(data[8]), double.Parse(data[7]), int.Parse(data[10]),
                double.Parse(data[9]), int.Parse(data[12]), double.Parse(data[11]));

            cars.Add(currentCar);
        }

        string command = Console.ReadLine();

        if (command == "flamable")
        {
            var flammableCargoCars = cars
                .Where(c => c.cargo.type == "flamable"
                && c.engine.power > 250)
                .Select(c => c.model)
                .ToList();

            foreach (var carModel in flammableCargoCars)
            {
                Console.WriteLine(carModel);
            }
        }
        else if (command == "fragile")
        {
            var fragileCargoCars = cars
                .Where(c => c.cargo.type == "fragile"
                && c.tires.Any(t => t.pressure < 1))
                .Select(c => c.model)
                .ToList();

            foreach (var carModel in fragileCargoCars)
            {
                Console.WriteLine(carModel);
            }
        }
    }
}