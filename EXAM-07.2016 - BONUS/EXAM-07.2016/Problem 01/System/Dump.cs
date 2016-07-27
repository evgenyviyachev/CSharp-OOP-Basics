using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Dump
{
    private static List<Hardware> dumpedHardware = new List<Hardware>();

    public static void AddHardware(Hardware currentHardware)
    {
        dumpedHardware.Add(currentHardware);
    }

    public static void RemoveHardwareFromDump(string hardwareName)
    {
        if (HasHardware(hardwareName))
        {
            dumpedHardware.RemoveAll(h => h.Name == hardwareName);
        }
    }

    public static Hardware ReturnHardware(string hardwareName)
    {
        if (HasHardware(hardwareName))
        {
            return dumpedHardware.First(h => h.Name == hardwareName);
        }

        return null;
    }

    private static bool HasHardware(string hardwareName)
    {
        return dumpedHardware.Any(h => h.Name == hardwareName);
    }

    public static string DumpAnalyze()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Dump Analysis").Append(Environment.NewLine)
                    .Append($"Power Hardware Components: {dumpedHardware.Where(h => h.Type == "Power").Count()}")
                    .Append(Environment.NewLine)
                    .Append($"Heavy Hardware Components: {dumpedHardware.Where(h => h.Type == "Heavy").Count()}")
                    .Append(Environment.NewLine)
                    .Append($"Express Software Components: {dumpedHardware.Sum(h => h.CountOfExpressSoftwareComponents())}")
                    .Append(Environment.NewLine)
                    .Append($"Light Software Components: {dumpedHardware.Sum(h => h.CountOfLightSoftwareComponents())}")
                    .Append(Environment.NewLine)
                    .Append($"Total Dumped Memory: {dumpedHardware.Sum(h => h.MemoryUsage())}")
                    .Append(Environment.NewLine)
                    .Append($"Total Dumped Capacity: {dumpedHardware.Sum(h => h.CapacityUsage())}");
        
        return sb.ToString();
    }
}