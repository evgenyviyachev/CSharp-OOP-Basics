using System;

public class AloneYoungPerson : Single
{
    private const int numberOfRooms = 1;
    private const decimal roomElectricity = 10;

    private decimal laptopCost;

    public AloneYoungPerson(decimal income, decimal laptopCost)
        : base(income, numberOfRooms, roomElectricity)
    {
        this.laptopCost = laptopCost;
    }

    public override decimal Consumption
    {
        get
        {
            return base.Consumption + this.laptopCost;
        }
    }
}