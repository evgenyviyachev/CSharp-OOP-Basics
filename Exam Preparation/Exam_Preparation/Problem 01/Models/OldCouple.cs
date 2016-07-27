using System;

public class OldCouple : Couple
{
    private const int numberOfRooms = 3;
    private const decimal roomElectricity = 15;

    private decimal stoveCost;

    public OldCouple(decimal pensionOne, decimal pensionTwo, decimal tvCost, decimal fridgeCost, decimal stoveCost)
        : base(pensionOne + pensionTwo, numberOfRooms, roomElectricity, tvCost, fridgeCost)
    {
        this.stoveCost = stoveCost;
    }

    public override decimal Consumption
    {
        get
        {
            return base.Consumption + this.stoveCost;
        }
    }
}