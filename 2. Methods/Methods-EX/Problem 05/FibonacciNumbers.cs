using System;
using System.Collections.Generic;
using System.Numerics;

public class Fibonacci
{
    public Fibonacci()
    {
        this.num = new List<BigInteger>();
        this.num.Add(0);
        this.num.Add(1);
        for (int i = 2; i < 100; i++)
        {
            this.num.Add(this.num[i - 2] + this.num[i - 1]);
        }
    }

    public List<BigInteger> num;

    public List<BigInteger> GetNumbersInRange(int startPos, int endPos)
    {
        int count = endPos - startPos;
        return this.num.GetRange(startPos, count);
    }
}

public class FibonacciNumbers
{
    public static void Main()
    {
        Fibonacci fibonacci = new Fibonacci();

        int startPos = int.Parse(Console.ReadLine());
        int endPos = int.Parse(Console.ReadLine());

        Console.WriteLine(string.Join(", ", fibonacci.GetNumbersInRange(startPos, endPos)));
    }
}