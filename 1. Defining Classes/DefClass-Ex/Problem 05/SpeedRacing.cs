using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    public Car(string model, decimal fuelAmount, decimal fuelCostFor1Km)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelCostFor1Km = fuelCostFor1Km;
        this.distanceTraveled = 0;
    }

    public string model;
    public decimal fuelAmount;
    public decimal fuelCostFor1Km;
    public decimal distanceTraveled;

    public void TravelKms(decimal kmsToTravel)
    {
        if (this.fuelAmount/this.fuelCostFor1Km >= kmsToTravel)
        {
            this.fuelAmount -= kmsToTravel * fuelCostFor1Km;
            this.distanceTraveled += kmsToTravel;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}

public class SpeedRacing
{
    public static void Main()
    {
        int carsCount = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < carsCount; i++)
        {
            string[] data = Console.ReadLine().Trim().Split();
            Car currentCar = new Car(data[0], decimal.Parse(data[1]), decimal.Parse(data[2]));
            cars.Add(currentCar);
        }

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] currentData = input.Trim().Split();
            string model = currentData[1];
            decimal kmsToTravel = decimal.Parse(currentData[2]);

            //int index = cars.IndexOf(cars.Where(c => c.model == model).FirstOrDefault());
            //cars[index].TravelKms(kmsToTravel);

            Car carToDrive = cars.FirstOrDefault(c => c.model == model);
            carToDrive.TravelKms(kmsToTravel);
            
            input = Console.ReadLine();
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.model} {car.fuelAmount:F2} {car.distanceTraveled}");
        }
    }
}