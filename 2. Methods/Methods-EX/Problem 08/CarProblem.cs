using System;
using System.Linq;

public class Car
{
    public Car(double speed, double fuel, double fuelEconomy)
    {
        this.speed = speed;
        this.fuel = fuel;
        this.fuelEconomy = fuelEconomy;
        this.kmsTraveled = 0;
        this.timeTraveled = 0;
    }

    private double speed;
    private double fuel;
    private double fuelEconomy;
    private double kmsTraveled;
    private double timeTraveled;

    public void Travel(double distance)
    {
        double distanceAllowed = (this.fuel / this.fuelEconomy) * this.speed;

        if (distance <= distanceAllowed)
        {
            double currentTimeTraveled = distance / this.speed;
            this.fuel -= currentTimeTraveled * this.fuelEconomy;
            this.kmsTraveled += distance;
            this.timeTraveled += currentTimeTraveled * 60;
        }
        else
        {
            double currentTimeTraveled = distanceAllowed / this.speed;
            this.fuel = 0;
            this.kmsTraveled += distanceAllowed;
            this.timeTraveled += currentTimeTraveled * 60;
        }
    }

    public void Refuel(double liters)
    {
        this.fuel += liters;
    }

    public void Distance()
    {
        Console.WriteLine($"Total distance: {this.kmsTraveled:F1} kilometers");
    }

    public void Time()
    {
        int hours = (int)this.timeTraveled / 60;
        int minutes = (int)this.timeTraveled % 60;
        Console.WriteLine($"Total time: {hours} hours and {minutes} minutes");
    }

    public void Fuel()
    {
        Console.WriteLine($"Fuel left: {this.fuel:F1} liters");
    }
}

public class CarProblem
{
    public static void Main()
    {
        double[] data = Console.ReadLine().Trim().Split().Select(double.Parse).ToArray();
        Car car = new Car(data[0], data[1], data[2]);

        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] commands = input.Split();
            if (commands.Length == 2 && commands[0] == "Travel")
            {
                car.Travel(double.Parse(commands[1]));
            }
            else if (commands.Length == 2 && commands[0] == "Refuel")
            {
                car.Refuel(double.Parse(commands[1]));
            }
            else if (commands[0] == "Distance")
            {
                car.Distance();
            }
            else if (commands[0] == "Time")
            {
                car.Time();
            }
            else if (commands[0] == "Fuel")
            {
                car.Fuel();
            }

            input = Console.ReadLine();
        }
    }
}