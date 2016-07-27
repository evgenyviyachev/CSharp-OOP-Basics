using System;

public class AloneOldPerson : Single
{
    private const int numberOfRooms = 1;
    private const decimal roomElectricity = 15;

    public AloneOldPerson(decimal income)
        : base(income, numberOfRooms, roomElectricity)
    {
    }
}