using System;
using System.Linq;

public class Child
{
    private decimal[] consumption;

    public Child(decimal[] consumption)
    {
        this.consumption = consumption;
    }

    public decimal GetTotalConsumption()
    {
        return this.consumption.Sum();
    }
}