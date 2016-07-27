using System;
using System.Linq;
using System.Reflection;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get
        {
            return this.length;
        }
        set
        {
            if (value > 0)
            {
                this.length = value;
            }
        }
    }

    public double Width
    {
        get
        {
            return this.width;
        }
        set
        {
            if (value > 0)
            {
                this.width = value;
            }
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }
        set
        {
            if (value > 0)
            {
                this.height = value;
            }
        }
    }

    public double SurfaceArea()
    {
        return 2 * (this.length * this.width + this.length * this.height + this.width * this.height);
    }

    public double LateralSurfaceArea()
    {
        return 2 * (this.length * this.height + this.width * this.height);
    }

    public double Volume()
    {
        return this.length * this.width * this.height;
    }
}

public class DataValidation
{
    public static void Main()
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        Box box = new Box(length, width, height);

        if (box.Width > 0 && box.Height > 0 && box.Length > 0)
        {
            Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
            Console.WriteLine($"Volume - {box.Volume():F2}");
        }
        else if (box.Width <= 0)
        {
            Console.WriteLine("Width cannot be zero or negative.");
        }
        else if (box.Height <= 0)
        {
            Console.WriteLine("Height cannot be zero or negative.");
        }
        else
        {
            Console.WriteLine("Length cannot be zero or negative.");
        }
    }
}