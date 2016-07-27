public abstract class Software
{
    public Software(string name, string type, int capacityConsumption, int memoryConsumption)
    {
        this.Name = name;
        this.Type = type;
        this.CapacityConsumption = capacityConsumption;
        this.MemoryConsumption = memoryConsumption;
    }

    public string Name { get; private set; }
    public string Type { get; private set; }
    public int CapacityConsumption { get; private set; }
    public int MemoryConsumption { get; private set; }
}