using System;

public abstract class Vehicle
{
    private double fuelQuantity;

    public Vehicle(double fuelQuantity, double fuelConsumptionPerKM, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKM = fuelConsumptionPerKM;
        this.TankCapacity = tankCapacity;
    }

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            this.fuelQuantity = value;
        }
    }

    public abstract double FuelConsumptionPerKM { get; set; }
    public double TankCapacity { get; set; }

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

    public virtual void Refuel(double liters)
    {
        if (this.FuelQuantity + liters < 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            return;
        }
        if (this.FuelQuantity + liters > this.TankCapacity)
        {
            Console.WriteLine("Cannot fit fuel in tank");
            return;
        }

        this.FuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumptionPerKM, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKM, tankCapacity)
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
}

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionPerKM, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKM, tankCapacity)
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
        if (this.FuelQuantity + 0.95 * liters < 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            return;
        }

        this.FuelQuantity += 0.95 * liters;
    }
}

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumptionPerKM, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKM, tankCapacity)
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
            this.fuelConsumptionPerKM = value;
        }
    }

    public void DriveFull(double kms)
    {
        double kmsAbleToTravel = (double)this.FuelQuantity / (this.FuelConsumptionPerKM + 1.4);

        if (kmsAbleToTravel >= kms)
        {
            this.FuelQuantity -= kms * (this.FuelConsumptionPerKM + 1.4);
            Console.WriteLine($"{this.GetType().Name} travelled {kms} km");
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
    }
}

public class VehiclesExtension
{
    public static void Main()
    {
        string[] carData = Console.ReadLine().Split();
        string[] truckData = Console.ReadLine().Split();
        string[] busData = Console.ReadLine().Split();

        Car car = new Car(double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));
        Truck truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));
        Bus bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));

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
                else if (command[1] == "Bus")
                {
                    bus.DriveFull(kms);
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
                else if (command[1] == "Bus")
                {
                    bus.Refuel(liters);
                }
            }
            else if (command[0] == "DriveEmpty")
            {
                double kms = double.Parse(command[2]);

                bus.Drive(kms);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }
}