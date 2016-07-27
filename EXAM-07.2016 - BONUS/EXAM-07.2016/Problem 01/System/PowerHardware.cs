using System;

public class PowerHardware : Hardware
{
    private const string type = "Power";

    public PowerHardware(string name, int maxCapacity, int maxMemory)
        : base(name, type, (int)Math.Round((0.25 * maxCapacity), 0, MidpointRounding.AwayFromZero), (int)Math.Round((1.75 * maxMemory), 0, MidpointRounding.AwayFromZero))
    {
    }
}