using System;

public class Student
{
    private string name;
    public static int numberOfStudents = 0;

    public Student(string name)
    {
        this.name = name;
        numberOfStudents++;
    }
}

public class Students
{
    public static void Main()
    {
        string input = Console.ReadLine();

        while (input != "End")
        {
            Student currentStudent = new Student(input);
            input = Console.ReadLine();
        }

        Console.WriteLine(Student.numberOfStudents);
    }
}