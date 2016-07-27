using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DecimalNumber
{
    public DecimalNumber(decimal num)
    {
        this.num = num;
    }

    public decimal num;

    public string Reversed()
    {
        char[] numToChars = this.num.ToString().ToCharArray();
        Array.Reverse(numToChars);
        return new string(numToChars);
    }
}

public class NumberReversed
{
    public static void Main()
    {
        decimal num = decimal.Parse(Console.ReadLine());

        DecimalNumber number = new DecimalNumber(num);

        Console.WriteLine(number.Reversed());
    }
}