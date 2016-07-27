using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class CorDraw
{
    public CorDraw(string shape, int width, int height = 0)
    {
        this.shape = shape;
        if (this.shape == "Square")
        {
            this.width = width;
            this.height = this.width;
        }
        else
        {
            this.width = width;
            this.height = height;
        }
    }

    private string shape;
    private int width;
    private int height;

    public abstract void Draw();
}

public class Square : CorDraw
{
    public Square(string shape, int width) : base(shape, width)
    {
        this.shape = shape;
        this.width = width;
    }

    private string shape;
    private int width;

    public override void Draw()
    {
        for (int i = 0; i < this.width; i++)
        {
            Console.Write("|");
            if (i == 0 || i == this.width - 1)
            {
                for (int j = 0; j < this.width; j++)
                {

                    Console.Write("-");
                }
            }
            else
            {
                for (int j = 0; j < this.width; j++)
                {

                    Console.Write(" ");
                }
            }
            Console.WriteLine("|");
        }
    }
}

public class Rectangle : CorDraw
{
    public Rectangle(string shape, int width, int height) : base(shape, width, height)
    {
        this.shape = shape;
        this.width = width;
        this.height = height;
    }

    private string shape;
    private int width;
    private int height;

    public override void Draw()
    {
        for (int i = 0; i < this.height; i++)
        {
            Console.Write("|");
            if (i == 0 || i == this.height - 1)
            {
                for (int j = 0; j < this.width; j++)
                {

                    Console.Write("-");
                }
            }
            else
            {
                for (int j = 0; j < this.width; j++)
                {

                    Console.Write(" ");
                }
            }
            Console.WriteLine("|");
        }
    }
}

public class DrawingTool
{
    public static void Main()
    {
        string shape = Console.ReadLine();
        if (shape == "Square")
        {
            int dimension = int.Parse(Console.ReadLine());
            CorDraw square = new Square(shape, dimension);
            square.Draw();
        }
        else
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            CorDraw rec = new Rectangle(shape, width, height);
            rec.Draw();
        }
    }
}