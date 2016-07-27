using System;
using System.Linq;

public class YoungCoupleWithChildren : YoungCouple
{
    private const int numberOfRooms = 2;
    private const decimal roomElectricity = 30;

    private Child[] children;

    public YoungCoupleWithChildren(decimal salaryOne, decimal salaryTwo, decimal tvCost, decimal fridgeCost, decimal laptopCost, Child[] children)
        : base(salaryOne + salaryTwo, numberOfRooms, roomElectricity, tvCost, fridgeCost, laptopCost)
    {
        this.children = children;
    }

    public override int Population
    {
        get
        {
            return base.Population + this.children.Length;
        }
    }

    public override decimal Consumption
    {
        get
        {
            return base.Consumption + this.children.Sum(ch => ch.GetTotalConsumption());
        }
    }
}