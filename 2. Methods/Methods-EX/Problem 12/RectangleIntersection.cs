using System;
using System.Collections.Generic;
using System.Linq;

public class Rectangle
{
    public Rectangle(string ID, double width, double height, double x0, double y0)
    {
        this.ID = ID;
        this.width = width;
        this.height = height;
        this.x0 = x0;
        this.y0 = y0;
    }

    public string ID;
    private double width;
    private double height;
    private double x0;
    private double y0;

    public string Intersect(Rectangle otherRect)
    {
        if (otherRect.x0 + otherRect.width < this.x0
            || otherRect.y0 + otherRect.height < this.y0
            || otherRect.x0 > this.x0 + this.width
            || otherRect.y0 > this.y0 + this.height)
        {
            return "false";
        }

        return "true";
    }
}

public class RectangleIntersection
{
    public static void Main()
    {
        int[] numRecsNumChecks = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<Rectangle> rectangles = new List<Rectangle>();

        for (int i = 0; i < numRecsNumChecks[0]; i++)
        {
            string[] rec = Console.ReadLine().Split();
            Rectangle currentRec = new Rectangle(rec[0], double.Parse(rec[1]), double.Parse(rec[2]), double.Parse(rec[3]), double.Parse(rec[4]));
            rectangles.Add(currentRec);
        }

        for (int i = 0; i < numRecsNumChecks[1]; i++)
        {
            string[] coupleToCheck = Console.ReadLine().Split();
            string firstRec = coupleToCheck[0];
            string secondRec = coupleToCheck[1];

            Rectangle recOne = rectangles.First(x => x.ID == firstRec);
            Rectangle recTwo = rectangles.First(x => x.ID == secondRec);

            Console.WriteLine(recOne.Intersect(recTwo));
        }
    }
}