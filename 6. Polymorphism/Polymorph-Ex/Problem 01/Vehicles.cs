using System;

public abstract class Vehicle
{
    public Vehicle(double fuelQuantity, double fuelConsumptionPerKM)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKM = fuelConsumptionPerKM;
    }

    public double FuelQuantity { get; set; }
    public abstract double FuelConsumptionPerKM { get; set; }

    public void Drive(double kms)
    {
        double kmsAbleToTravel = (double)this.FuelQuantity / this.FuelConsumptionPerKM;

        if (kmsAbleToTravel >= kms)
        {
            this.FuelQuantity -= kms * this.FuelConsumptionPerKM;
            Console.WriteLine($"{this.GetType().Name} travelled {kms} km");
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
    }

    public abstract void Refuel(double liters);

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumptionPerKM)
        : base(fuelQuantity, fuelConsumptionPerKM)
    {
        this.FuelConsumptionPerKM = fuelConsumptionPerKM;
    }

    private double fuelConsumptionPerKM;

    public override double FuelConsumptionPerKM
    {
        get
        {
            return this.fuelConsumptionPerKM;
        }

        set
        {
            this.fuelConsumptionPerKM = value + 0.9;
        }
    }

    public override void Refuel(double liters)
    {
        this.FuelQuantity += liters;
    }
}

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionPerKM)
        : base(fuelQuantity, fuelConsumptionPerKM)
    {
        this.FuelConsumptionPerKM = fuelConsumptionPerKM;
    }

    private double fuelConsumptionPerKM;

    public override double FuelConsumptionPerKM
    {
        get
        {
            return this.fuelConsumptionPerKM;
        }

        set
        {
            this.fuelConsumptionPerKM = value + 1.6;
        }
    }

    public override void Refuel(double liters)
    {
        this.FuelQuantity += 0.95 * liters;
    }
}

public class Vehicles
{
    public static void Main()
    {
        string[] carData = Console.ReadLine().Split();
        string[] truckData = Console.ReadLine().Split();

        Vehicle car = new Car(double.Parse(carData[1]), double.Parse(carData[2]));
        Vehicle truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]));

        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] command = Console.ReadLine().Split();

            if (command[0] == "Drive")
            {
                double kms = double.Parse(command[2]);

                if (command[1] == "Car")
                {
                    car.Drive(kms);
                }
                else if (command[1] == "Truck")
                {
                    truck.Drive(kms);
                }
            }
            else if (command[0] == "Refuel")
            {
                double liters = double.Parse(command[2]);

                if (command[1] == "Car")
                {
                    car.Refuel(liters);
                }
                else if (command[1] == "Truck")
                {
                    truck.Refuel(liters);
                }
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }
}