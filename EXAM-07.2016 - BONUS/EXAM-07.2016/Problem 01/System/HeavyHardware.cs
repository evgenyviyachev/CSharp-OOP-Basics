using System;

public class HeavyHardware : Hardware
{
    private const string type = "Heavy";

    public HeavyHardware(string name, int maxCapacity, int maxMemory)
        : base(name, type, 2 * maxCapacity, (int)Math.Round((0.75 * maxMemory), 0, MidpointRounding.AwayFromZero))
    {
    }
}