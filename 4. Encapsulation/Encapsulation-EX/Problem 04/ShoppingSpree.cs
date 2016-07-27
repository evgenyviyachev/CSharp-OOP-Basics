using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private double money;
    private List<Product> products;

    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.products = new List<Product>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value.Length == 0)
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public double Money
    {
        get
        {
            return this.money;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public List<Product> Products
    {
        get
        {
            return this.products;
        }
    }
}

public class Product
{
    private string name;
    private double cost;

    public Product(string name, double cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value.Length == 0)
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public double Cost
    {
        get
        {
            return this.cost;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.cost = value;
        }
    }
}

public class ShoppingSpree
{
    public static void Main()
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        string[] peopleMoney = Console.ReadLine().Trim(new[] { ';', ' ' }).Split(';');

        for (int i = 0; i < peopleMoney.Length; i++)
        {
            string[] currentPersonMoney = peopleMoney[i].Split('=');
            string name = currentPersonMoney[0];
            double money = double.Parse(currentPersonMoney[1]);
            try
            {
                Person currentPerson = new Person(name, money);
                people.Add(currentPerson);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        string[] productsCost = Console.ReadLine().Trim(new[] { ';', ' ' }).Split(';');

        for (int i = 0; i < productsCost.Length; i++)
        {
            string[] currentProductCost = productsCost[i].Split('=');
            string name = currentProductCost[0];
            double cost = double.Parse(currentProductCost[1]);

            try
            {
                Product currentProduct = new Product(name, cost);
                products.Add(currentProduct);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }            
        }

        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] currentOrder = input.Split();
            string personName = currentOrder[0];
            string productName = currentOrder[1];

            Person person = people.First(p => p.Name == personName);
            Product product = products.First(pr => pr.Name == productName);

            if (person.Money >= product.Cost)
            {
                Console.WriteLine($"{person.Name} bought {product.Name}");
                person.Products.Add(product);
                person.Money -= product.Cost;
            }
            else
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }

            input = Console.ReadLine();
        }

        foreach (var person in people)
        {
            if (person.Products.Count > 0)
            {
                Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(pr => pr.Name).ToList())}");
            }
            else
            {
                Console.WriteLine($"{person.Name} - Nothing bought");
            }            
        }
    }
}