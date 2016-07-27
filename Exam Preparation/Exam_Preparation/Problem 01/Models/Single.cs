using System;

public class Single : HouseHold
{
    //private const int numberOfRooms = 1;

    public Single(decimal income, int numberOfRooms, decimal roomElectricity)
        : base(income, numberOfRooms, roomElectricity)
    {
    }
}