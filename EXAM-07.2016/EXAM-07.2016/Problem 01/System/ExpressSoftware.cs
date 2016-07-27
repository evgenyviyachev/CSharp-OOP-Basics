public class ExpressSoftware : Software
{
    private const string type = "Express";

    public ExpressSoftware(string name, int capacityConsumption, int memoryConsumption)
        : base(name, type, capacityConsumption, 2 * memoryConsumption)
    {
    }
}