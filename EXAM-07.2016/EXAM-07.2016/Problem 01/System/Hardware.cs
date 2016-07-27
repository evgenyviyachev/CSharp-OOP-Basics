using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Hardware
{
    private List<Software> software;

    public Hardware(string name, string type, int maxCapacity, int maxMemory)
    {
        this.Name = name;
        this.Type = type;
        this.MaxCapacity = maxCapacity;
        this.MaxMemory = maxMemory;
        this.software = new List<Software>();
    }

    public string Name { get; private set; }
    public string Type { get; private set; }
    public int MaxCapacity { get; private set; }
    public int MaxMemory { get; private set; }

    public void StoreSoftware(Software currentSoftware)
    {
        int softwareCapacityConsumption = currentSoftware.CapacityConsumption;
        int softwareMemoryConsumption = currentSoftware.MemoryConsumption;
        int totalCapacityConsumed = this.software.Sum(s => s.CapacityConsumption);
        int totalMemoryConsumed = this.software.Sum(s => s.MemoryConsumption);

        if (softwareCapacityConsumption + totalCapacityConsumed <= this.MaxCapacity
            && softwareMemoryConsumption + totalMemoryConsumed <= this.MaxMemory)
        {
            this.software.Add(currentSoftware);
        }
    }

    public void ReleaseSoftware(string name)
    {
        if (this.software.Any(s => s.Name == name))
        {
            this.software.RemoveAll(s => s.Name == name);
        }
    }

    public int CountOfSoftwareComponents()
    {
        return this.software.Count();
    }

    public int MemoryUsage()
    {
        return this.software.Sum(s => s.MemoryConsumption);
    }

    public int CapacityUsage()
    {
        return this.software.Sum(s => s.CapacityConsumption);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"Hardware Component - {this.Name}").Append(Environment.NewLine)
            .Append($"Express Software Components - {this.software.Where(s => s.Type == "Express").Count()}")
            .Append(Environment.NewLine)
            .Append($"Light Software Components - {this.software.Where(s => s.Type == "Light").Count()}")
            .Append(Environment.NewLine)
            .Append($"Memory Usage: {this.MemoryUsage()} / {this.MaxMemory}")
            .Append(Environment.NewLine)
            .Append($"Capacity Usage: {this.CapacityUsage()} / {this.MaxCapacity}")
            .Append(Environment.NewLine)
            .Append($"Type: {this.Type}")
            .Append(Environment.NewLine);

        if (this.software.Count == 0)
        {
            sb.Append("Software Components: None");
        }
        else
        {
            sb.Append($"Software Components: {string.Join(", ", this.software.Select(s => s.Name).ToList())}");
        }

        return sb.ToString();
    }
}