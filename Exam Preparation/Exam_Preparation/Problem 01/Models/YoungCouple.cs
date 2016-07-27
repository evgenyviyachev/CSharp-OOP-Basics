using System;

public class YoungCouple : Couple
{
    private const int numberOfRooms = 2;
    private const decimal roomElectricity = 20;

    private decimal laptopCost;
    
    public YoungCouple(decimal salaryOne, decimal salaryTwo, decimal tvCost, decimal fridgeCost, decimal laptopCost)
        : base(salaryOne + salaryTwo, numberOfRooms, roomElectricity, tvCost, fridgeCost)
    {
        this.laptopCost = laptopCost;
    }

    //for derived class YoungCoupleWithChildren - different numberOfRoos & roomElectricity
    protected YoungCouple(decimal income, int numberOfRooms, decimal roomElectricity, decimal tvCost, decimal fridgeCost, decimal laptopCost)
        : base(income, numberOfRooms, roomElectricity, tvCost, fridgeCost)
    {
        this.laptopCost = laptopCost;
    }

    public override decimal Consumption
    {
        get
        {
            return base.Consumption + this.laptopCost * 2;
        }
    }
}