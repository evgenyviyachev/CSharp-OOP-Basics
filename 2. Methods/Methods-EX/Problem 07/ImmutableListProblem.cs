using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ImmutableList
{
    public List<int> collection;

    public ImmutableList(List<int> collection)
    {
        if (collection != null)
        {
            this.collection = collection;
        }
        else
        {
            this.collection = new List<int>();
        }
    }

    public ImmutableList Get()
    {
        List<int> newCollection = new List<int>(this.collection);
        var newImmutableList = new ImmutableList(newCollection);
        return newImmutableList;
    }
}

public class ImmutableListProblem
{
    public static void Main()
    {
        //Test:
        //var firstCol = new ImmutableList(new List<int>());
        //var secondCol = firstCol.Get();

        //firstCol.collection.Add(20);

        //Should disply '0':
        //Console.WriteLine(secondCol.collection.Count);
        //return;

        Type immutableList = typeof(ImmutableList);
        FieldInfo[] fields = immutableList.GetFields();
        if (fields.Length < 1)
        {
            throw new Exception();
        }
        else
        {
            Console.WriteLine(fields.Length);
        }

        MethodInfo[] methods = immutableList.GetMethods();
        bool containsMethod = methods.Any(m => m.ReturnType.Name.Equals("ImmutableList"));
        if (!containsMethod)
        {
            throw new Exception();
        }
        else
        {
            Console.WriteLine(methods[0].ReturnType.Name);
        }
    }
}