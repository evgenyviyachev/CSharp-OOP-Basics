using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public Person(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
        this.children = new List<Child>();
        this.parents = new List<Parent>();
    }

    public string name;
    public string birthday;
    public List<Child> children;
    public List<Parent> parents;
}

public class Child
{
    public Child(string childName, string childBirthday)
    {
        this.childName = childName;
        this.childBirthday = childBirthday;
    }

    public string childName;
    public string childBirthday;
}

public class Parent
{
    public Parent(string parentName, string parentBirthday)
    {
        this.parentName = parentName;
        this.parentBirthday = parentBirthday;
    }

    public string parentName;
    public string parentBirthday;
}

public class FamilyTree
{
    public static void Main()
    {
        string personToDisplayNameOrBirthday = Console.ReadLine();
        List<Person> people = new List<Person>();

        string input = Console.ReadLine();
        while (input != "End")
        {
            if (input.Contains("-"))
            {
                string[] data = input.Split('-').Select(s => s.Trim()).ToArray();
                if (!char.IsDigit(data[0][0]))
                {
                    if (!char.IsDigit(data[1][0]))
                    {
                        string parentName = data[0];
                        string childName = data[1];

                        if (people.Any(p => p.name == parentName))
                        {
                            Person currentPerson = people.First(p => p.name == parentName);
                            if (!currentPerson.children.Any(c => c.childName == childName))
                            {
                                currentPerson.children.Add(new Child(childName, ""));
                            }
                        }
                        else
                        {
                            Person newPerson = new Person(parentName, "");
                            newPerson.children.Add(new Child(childName, ""));
                            people.Add(newPerson);
                        }

                        if (people.Any(p => p.name == childName))
                        {
                            Person currentPerson = people.First(p => p.name == childName);
                            if (!currentPerson.parents.Any(par => par.parentName == parentName))
                            {
                                currentPerson.parents.Add(new Parent(parentName, ""));
                            }
                        }
                        else
                        {
                            Person newPerson = new Person(childName, "");
                            newPerson.parents.Add(new Parent(parentName, ""));
                            people.Add(newPerson);
                        }
                    }
                    else
                    {
                        string parentName = data[0];
                        string childBirthday = data[1];

                        if (people.Any(p => p.name == parentName))
                        {
                            Person currentPerson = people.First(p => p.name == parentName);
                            if (!currentPerson.children.Any(c => c.childBirthday == childBirthday))
                            {
                                currentPerson.children.Add(new Child("", childBirthday));
                            }
                        }
                        else
                        {
                            Person newPerson = new Person(parentName, "");
                            newPerson.children.Add(new Child("", childBirthday));
                            people.Add(newPerson);
                        }

                        if (people.Any(p => p.birthday == childBirthday))
                        {
                            Person currentPerson = people.First(p => p.birthday == childBirthday);
                            if (!currentPerson.parents.Any(par => par.parentName == parentName))
                            {
                                currentPerson.parents.Add(new Parent(parentName, ""));
                            }
                        }
                        else
                        {
                            Person newPerson = new Person("", childBirthday);
                            newPerson.parents.Add(new Parent(parentName, ""));
                            people.Add(newPerson);
                        }
                    }
                }
                else
                {
                    if (!char.IsDigit(data[1][0]))
                    {
                        string parentBirthday = data[0];
                        string childName = data[1];

                        if (people.Any(p => p.birthday == parentBirthday))
                        {
                            Person currentPerson = people.First(p => p.birthday == parentBirthday);
                            if (!currentPerson.children.Any(c => c.childName == childName))
                            {
                                currentPerson.children.Add(new Child(childName, ""));
                            }
                        }
                        else
                        {
                            Person newPerson = new Person("", parentBirthday);
                            newPerson.children.Add(new Child(childName, ""));
                            people.Add(newPerson);
                        }

                        if (people.Any(p => p.name == childName))
                        {
                            Person currentPerson = people.First(p => p.name == childName);
                            if (!currentPerson.parents.Any(par => par.parentBirthday == parentBirthday))
                            {
                                currentPerson.parents.Add(new Parent("", parentBirthday));
                            }
                        }
                        else
                        {
                            Person newPerson = new Person(childName, "");
                            newPerson.parents.Add(new Parent("", parentBirthday));
                            people.Add(newPerson);
                        }
                    }
                    else
                    {
                        string parentBirthday = data[0];
                        string childBirthday = data[1];

                        if (people.Any(p => p.birthday == parentBirthday))
                        {
                            Person currentPerson = people.First(p => p.birthday == parentBirthday);
                            if (!currentPerson.children.Any(c => c.childBirthday == childBirthday))
                            {
                                currentPerson.children.Add(new Child("", childBirthday));
                            }
                        }
                        else
                        {
                            Person newPerson = new Person("", parentBirthday);
                            newPerson.children.Add(new Child("", childBirthday));
                            people.Add(newPerson);
                        }

                        if (people.Any(p => p.birthday == childBirthday))
                        {
                            Person currentPerson = people.First(p => p.birthday == childBirthday);
                            if (!currentPerson.parents.Any(par => par.parentBirthday == parentBirthday))
                            {
                                currentPerson.parents.Add(new Parent("", parentBirthday));
                            }
                        }
                        else
                        {
                            Person newPerson = new Person("", childBirthday);
                            newPerson.parents.Add(new Parent("", parentBirthday));
                            people.Add(newPerson);
                        }
                    }
                }
            }
            else
            {
                string[] currentData = input.Split();
                string fullName = currentData[0] + " " + currentData[1];
                string birthday = currentData[2];

                if (people.Any(p => p.name == fullName)
                    || people.Any(p => p.birthday == birthday))
                {
                    if (people.Any(p => p.name == fullName))
                    {
                        Person currentPerson = people.First(p => p.name == fullName);
                        if (currentPerson.birthday == "")
                        {
                            currentPerson.birthday = birthday;
                        }
                    }
                    if (people.Any(p => p.birthday == birthday))
                    {
                        Person currentPerson = people.First(p => p.birthday == birthday);
                        if (currentPerson.name == "")
                        {
                            currentPerson.name = fullName;
                        }
                    }
                }
                else
                {
                    Person newPerson = new Person(fullName, birthday);
                    people.Add(newPerson);
                }
            }

            input = Console.ReadLine();
        }

        Person person = new Person("", "");
        if (!char.IsDigit(personToDisplayNameOrBirthday[0]))
        {
            person = people.FirstOrDefault(p => p.name == personToDisplayNameOrBirthday);
        }
        else
        {
            person = people.FirstOrDefault(p => p.birthday == personToDisplayNameOrBirthday);
        }

        Console.WriteLine($"{person.name} {person.birthday}");
        Console.WriteLine("Parents:");
        foreach (var isParent in people)
        {
            if (isParent.children.Any(c => c.childName == person.name)
                || isParent.children.Any(c => c.childBirthday == person.birthday))
            {
                Console.WriteLine($"{isParent.name} {isParent.birthday}");
            }
        }
        Console.WriteLine("Children:");
        foreach (var isChild in people)
        {
            if (isChild.parents.Any(par => par.parentName == person.name)
                || isChild.parents.Any(par => par.parentBirthday == person.birthday))
            {
                Console.WriteLine($"{isChild.name} {isChild.birthday}");
            }
        }
    }
}