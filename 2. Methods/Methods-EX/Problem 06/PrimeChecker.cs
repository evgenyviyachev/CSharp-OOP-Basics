using System;

public class Number
{
    public Number(long num)
    {
        this.num = num;
        this.isPrime = true;
        for (int i = 2; i <= Math.Sqrt(Math.Abs(this.num)); i++)
        {
            if (this.num % i == 0)
            {
                this.isPrime = false;
            }
        }
    }

    private long num;
    private bool isPrime;

    public long Num => this.num;
    public bool IsPrime => this.isPrime;

    public long NextPrime()
    {                
        while (true)
        {
            this.num++;
            if (IsPrimeMethod(this.num))
            {
                return this.num;
            }
        }
    }

    public bool IsPrimeMethod(long number)
    {
        for (int i = 2; i <= Math.Sqrt(Math.Abs(number)); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}

public class PrimeChecker
{
    public static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        Number num = new Number(number);

        Console.WriteLine(num.NextPrime() + ", " + num.IsPrime.ToString().ToLower());
    }
}