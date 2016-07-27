using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        int counter = 1;
        string input = Console.ReadLine();
        List<HouseHold> Kermen = new List<HouseHold>();

        while (input != "Democracy")
        {
            try
            {
                HouseHold entity = HouseHoldFactory.CreateHouseHold(input);
                Kermen.Add(entity);
            }
            catch (Exception)
            {

            }

            if (counter % 3 == 0)
            {
                foreach (var houseHold in Kermen)
                {
                    houseHold.GetIncome();
                }
            }

            if (input == "EVN bill")
            {
                Kermen.RemoveAll(x => x.CanPayBills() == false);

                foreach (var houseHold in Kermen)
                {
                    houseHold.PayBills();
                }
            }

            if (input == "EVN")
            {
                Console.WriteLine($"Total consumption: {Kermen.Sum(hh => hh.Consumption)}");
            }
            input = Console.ReadLine();
            counter++;
        }

        Console.WriteLine($"Total population: {Kermen.Sum(hh => hh.Population)}");
    }
}