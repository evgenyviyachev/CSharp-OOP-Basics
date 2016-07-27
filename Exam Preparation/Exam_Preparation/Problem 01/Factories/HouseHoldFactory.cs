using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class HouseHoldFactory
{
    public static HouseHold CreateHouseHold(string input)
    {
        string pattern = @"(\w+)\(([\d\.\, ]+)\)";
        Regex rgx = new Regex(pattern);
        MatchCollection matches = rgx.Matches(input);

        if (rgx.IsMatch(input))
        {
            string houseHoldType = matches[0].Groups[1].Value;
            if (houseHoldType == "YoungCouple")
            {
                decimal[] salaries = matches[0].Groups[2].Value.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
                decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
                decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);

                return new YoungCouple(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost);
            }
            else if (houseHoldType == "YoungCoupleWithChildren")
            {
                decimal[] salaries = matches[0].Groups[2].Value.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
                decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
                decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);
                Child[] children = new Child[matches.Count - 4];

                for (int i = 4; i < matches.Count; i++)
                {
                    decimal[] consumption = matches[i].Groups[2].Value.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
                    children[i - 4] = new Child(consumption);
                }

                return new YoungCoupleWithChildren(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost, children);
            }
            else if (houseHoldType == "AloneYoung")
            {
                decimal salary = decimal.Parse(matches[0].Groups[2].Value);
                decimal laptopCost = decimal.Parse(matches[1].Groups[2].Value);

                return new AloneYoungPerson(salary, laptopCost);
            }
            else if (houseHoldType == "OldCouple")
            {
                decimal[] pensions = matches[0].Groups[2].Value.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
                decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
                decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                decimal stoveCost = decimal.Parse(matches[3].Groups[2].Value);

                return new OldCouple(pensions[0], pensions[1], tvCost, fridgeCost, stoveCost);
            }
            else
            {
                decimal pension = decimal.Parse(matches[0].Groups[2].Value);

                return new AloneOldPerson(pension);
            }
        }
        else
        {
            throw new ArgumentException("Invalid household.");
        }
    }
}