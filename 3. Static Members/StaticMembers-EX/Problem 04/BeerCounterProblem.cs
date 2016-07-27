using System;
using System.Collections.Generic;
using System.Linq;

public class BeerCounter
{
    static BeerCounter()
    {
        beerInStock = 0;
        beerDrunkCount = 0;
    }

    public static int beerInStock;
    public static int beerDrunkCount;

    public static void BuyBeer(int bottlesCount)
    {
        beerInStock += bottlesCount;
    }

    public static void DrinkBeer(int bottlesCount)
    {
        beerInStock -= bottlesCount;
        beerDrunkCount += bottlesCount;
    }
}

public class BeerCounterProblem
{
    public static void Main()
    {
        string input = Console.ReadLine();
        BeerCounter beerCounter = new BeerCounter();

        while (input != "End")
        {
            int[] beerInfo = input.Trim().Split().Select(int.Parse).ToArray();
            int beerBought = beerInfo[0];
            int beerDrunk = beerInfo[1];

            BeerCounter.BuyBeer(beerBought);
            BeerCounter.DrinkBeer(beerDrunk);

            input = Console.ReadLine();
        }

        Console.WriteLine($"{BeerCounter.beerInStock} {BeerCounter.beerDrunkCount}");
    }
}