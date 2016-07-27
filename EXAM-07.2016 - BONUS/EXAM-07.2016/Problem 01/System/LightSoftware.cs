using System;

public class LightSoftware : Software
{
    private const string type = "Light";

    public LightSoftware(string name, int capacityConsumption, int memoryConsumption)
        : base(name, type, (int)Math.Round((1.5 * capacityConsumption), 0, MidpointRounding.AwayFromZero), (int)Math.Round((0.5 * memoryConsumption), 0, MidpointRounding.AwayFromZero))
    {
    }
}