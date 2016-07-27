using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Number
{
    public Number(int num)
    {
        this.num = num;
    }

    public int num;

    public void LastDigitName()
    {
        string number = this.num.ToString();
        string lastDigit = number.Substring(number.Length - 1);

        switch (lastDigit)
        {
            case "0":
                Console.WriteLine("zero");
                break;
            case "1":
                Console.WriteLine("one");
                break;
            case "2":
                Console.WriteLine("two");
                break;
            case "3":
                Console.WriteLine("three");
                break;
            case "4":
                Console.WriteLine("four");
                break;
            case "5":
                Console.WriteLine("five");
                break;
            case "6":
                Console.WriteLine("six");
                break;
            case "7":
                Console.WriteLine("seven");
                break;
            case "8":
                Console.WriteLine("eight");
                break;
            case "9":
                Console.WriteLine("nine");
                break;
            default:
                break;
        }
    }
}

public class LastDigitName
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        Number num = new Number(number);

        num.LastDigitName();
    }
}