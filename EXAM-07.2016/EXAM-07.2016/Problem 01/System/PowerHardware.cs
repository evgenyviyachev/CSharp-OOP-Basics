public class PowerHardware : Hardware
{
    private const string type = "Power";

    public PowerHardware(string name, int maxCapacity, int maxMemory)
        : base(name, type, (int)(0.25 * maxCapacity), (int)(1.75 * maxMemory))
    {
    }
}