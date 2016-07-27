using System;
using System.Collections.Generic;
using System.Linq;

public class SiameseCat : Cat
{
    public SiameseCat(string name, string breed, int earSize)
    {
        this.name = name;
        this.breed = breed;
        this.earSize = earSize;
    }

    public int earSize;

    public override string ToString()
    {
        return $"{this.breed} {this.name} {this.earSize}";
    }
}

public class CymricCat : Cat
{
    public CymricCat(string name, string breed, double furLength)
    {
        this.name = name;
        this.breed = breed;
        this.furLength = furLength;
    }

    public double furLength;

    public override string ToString()
    {
        return $"{this.breed} {this.name} {this.furLength:F2}";
    }
}

public class StreetExtraordinaireCat : Cat
{
    public StreetExtraordinaireCat(string name, string breed, int decibel)
    {
        this.name = name;
        this.breed = breed;
        this.decibel = decibel;
    }

    public int decibel;

    public override string ToString()
    {
        return $"{this.breed} {this.name} {this.decibel}";
    }
}

public class Cat
{
    public string name;
    public string breed;
}

class CatLady
{
    static void Main()
    {
        List<Cat> cats = new List<Cat>();
        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] currentData = input.Trim().Split();
            if (currentData[0] == "Siamese")
            {
                SiameseCat currentCat = new SiameseCat(currentData[1], currentData[0], int.Parse(currentData[2]));
                cats.Add(currentCat);
            }
            else if (currentData[0] == "Cymric")
            {
                CymricCat currentCat = new CymricCat(currentData[1], currentData[0], double.Parse(currentData[2]));
                cats.Add(currentCat);
            }
            else
            {
                StreetExtraordinaireCat currentCat = new StreetExtraordinaireCat(currentData[1], currentData[0], int.Parse(currentData[2]));
                cats.Add(currentCat);
            }

            input = Console.ReadLine();
        }

        string nameOfCatToDisplay = Console.ReadLine();

        Cat catToDisplay = cats.First(c => c.name == nameOfCatToDisplay);

        Console.WriteLine(catToDisplay.ToString());
    }
}