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
        this.length = length;
        this.width = width;
        this.height = height;
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

public class ClassBox
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

        Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
        Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
        Console.WriteLine($"Volume - {box.Volume():F2}");
    }
}