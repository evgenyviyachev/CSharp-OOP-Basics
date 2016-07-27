public class LightSoftware : Software
{
    private const string type = "Light";

    public LightSoftware(string name, int capacityConsumption, int memoryConsumption)
        : base(name, type, (int)(1.5 * capacityConsumption), (int)(0.5 * memoryConsumption))
    {
    }
}