using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string name;

    public Student(string name)
    {
        this.name = name;
    }
}

public class StudentGroup
{
    private HashSet<Student> students;
    public static int countOfStudents;

    public StudentGroup()
    {
        this.students = new HashSet<Student>();
        countOfStudents = 0;
    }

    public void AddStudent(Student student)
    {
        if (!this.students.Any(x => x.name == student.name))
        {
            this.students.Add(student);
            countOfStudents++;
        }
    }
}

public class UniqueStudentNames
{
    public static void Main()
    {
        string input = Console.ReadLine();
        StudentGroup studentGroup = new StudentGroup();

        while (input != "End")
        {
            Student currentStudent = new Student(input);
            studentGroup.AddStudent(currentStudent);
            input = Console.ReadLine();
        }

        Console.WriteLine(StudentGroup.countOfStudents);
    }
}