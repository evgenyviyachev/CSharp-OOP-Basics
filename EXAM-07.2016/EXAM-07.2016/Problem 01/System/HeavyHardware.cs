public class HeavyHardware : Hardware
{
    private const string type = "Heavy";

    public HeavyHardware(string name, int maxCapacity, int maxMemory)
        : base(name, type, 2 * maxCapacity, (int)(0.75 * maxMemory))
    {
    }
}