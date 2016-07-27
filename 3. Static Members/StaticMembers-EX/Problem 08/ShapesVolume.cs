using System;

public class TriangularPrism
{
    public double baseSide;
    public double heightBaseSide;
    public double length;

    public TriangularPrism(double baseSide, double heightBaseSide, double length)
    {
        this.baseSide = baseSide;
        this.heightBaseSide = heightBaseSide;
        this.length = length;
    }
}

public class Cube
{
    public double sideLength;

    public Cube(double sideLength)
    {
        this.sideLength = sideLength;
    }
}

public class Cylinder
{
    public double radius;
    public double height;

    public Cylinder(double radius, double height)
    {
        this.radius = radius;
        this.height = height;
    }
}

public static class VolumeCalculator
{
    public static void VolumeTrPrism(TriangularPrism prism)
    {
        double volume = (prism.baseSide * prism.heightBaseSide * prism.length) / 2;
        Console.WriteLine($"{volume:F3}");
    }

    public static void VolumeCube(Cube cube)
    {
        double volume = Math.Pow(cube.sideLength, 3);
        Console.WriteLine($"{volume:F3}");
    }

    public static void VolumeCylinder(Cylinder cylinder)
    {
        double volume = Math.PI * Math.Pow(cylinder.radius, 2) * cylinder.height;
        Console.WriteLine($"{volume:F3}");
    }
}

public class ShapesVolume
{
    public static void Main()
    {
        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] data = input.Trim().Split();

            switch (data[0])
            {
                case "TrianglePrism":
                    TriangularPrism currentPrism = new TriangularPrism(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));
                    VolumeCalculator.VolumeTrPrism(currentPrism);
                    break;
                case "Cube":
                    Cube currentCube = new Cube(double.Parse(data[1]));
                    VolumeCalculator.VolumeCube(currentCube);
                    break;
                case "Cylinder":
                    Cylinder currentCylinder = new Cylinder(double.Parse(data[1]), double.Parse(data[2]));
                    VolumeCalculator.VolumeCylinder(currentCylinder);
                    break;                
                default:
                    break;
            }

            input = Console.ReadLine();
        }
    }
}