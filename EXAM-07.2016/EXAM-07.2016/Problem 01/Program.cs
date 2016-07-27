using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<Hardware> hardware = new List<Hardware>();
        Regex rgx = new Regex(@"\(([ ,\d\w]*)\)");

        while (input != "System Split")
        {
            Match match = rgx.Match(input);
            string[] data = match.Groups[1].Value.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (input.StartsWith("RegisterP"))
            {
                hardware.Add(new PowerHardware(data[0], int.Parse(data[1]), int.Parse(data[2])));
            }
            else if (input.StartsWith("RegisterH"))
            {
                hardware.Add(new HeavyHardware(data[0], int.Parse(data[1]), int.Parse(data[2])));
            }
            else if (input.StartsWith("RegisterE"))
            {
                string hardwareName = data[0];

                if (hardware.Any(h => h.Name == hardwareName))
                {
                    Hardware currentHardware = hardware.First(h => h.Name == hardwareName);
                    currentHardware.StoreSoftware(new ExpressSoftware(data[1], int.Parse(data[2]), int.Parse(data[3])));
                }
            }
            else if (input.StartsWith("RegisterL"))
            {
                string hardwareName = data[0];

                if (hardware.Any(h => h.Name == hardwareName))
                {
                    Hardware currentHardware = hardware.First(h => h.Name == hardwareName);
                    currentHardware.StoreSoftware(new LightSoftware(data[1], int.Parse(data[2]), int.Parse(data[3])));
                }
            }
            else if (input.StartsWith("Release"))
            {
                string hardwareName = data[0];
                string softwareName = data[1];

                if (hardware.Any(h => h.Name == hardwareName))
                {
                    Hardware currentHardware = hardware.First(h => h.Name == hardwareName);
                    currentHardware.ReleaseSoftware(softwareName);
                }
            }
            else if (input.StartsWith("Analyze"))
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("System Analysis").Append(Environment.NewLine)
                    .Append($"Hardware Components: {hardware.Count()}")
                    .Append(Environment.NewLine)
                    .Append($"Software Components: {hardware.Sum(h => h.CountOfSoftwareComponents())}")
                    .Append(Environment.NewLine)
                    .Append($"Total Operational Memory: {hardware.Sum(h => h.MemoryUsage())} / {hardware.Sum(h => h.MaxMemory)}")
                    .Append(Environment.NewLine)
                    .Append($"Total Capacity Taken: {hardware.Sum(h => h.CapacityUsage())} / {hardware.Sum(h => h.MaxCapacity)}");

                Console.WriteLine(sb.ToString());
            }

            input = Console.ReadLine();
        }

        var powerHardware = hardware.Where(h => h.Type == "Power").ToList();
        var heavyHardware = hardware.Where(h => h.Type == "Heavy").ToList();

        foreach (var powerH in powerHardware)
        {
            Console.WriteLine(powerH);
        }
        foreach (var heavyH in heavyHardware)
        {
            Console.WriteLine(heavyH);
        }
    }
}