using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public Employee(string name, decimal salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = @"n/a";
        this.age = -1;
    }

    public string name;
    public decimal salary;
    public string position;
    public string department;
    public string email;
    public int age;
}

public class CompanyRoster
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < lines; i++)
        {
            try
            {
                string input = Console.ReadLine();
                string[] data = input.Split().Select(x => x.Trim()).ToArray();
                string name = data[0];
                decimal salary = decimal.Parse(data[1]);
                string position = data[2];
                string department = data[3];

                Employee currentEmployee = new Employee(name, salary, position, department);

                if (data.Length == 6)
                {
                    string email = data[4];
                    currentEmployee.email = email;
                    int age = int.Parse(data[5]);
                    currentEmployee.age = age;
                }
                else if (data.Length == 5)
                {
                    string emailOrAge = data[4];
                    int num;
                    bool isNumeric = int.TryParse(emailOrAge, out num);

                    if (!isNumeric)
                    {
                        currentEmployee.email = emailOrAge;
                    }
                    else
                    {
                        currentEmployee.age = num;
                    }
                }

                employees.Add(currentEmployee);
            }
            catch (Exception)
            {
                
            }            
        }

        var highestPaidDepartment = employees
            .GroupBy(e => e.department)
            .Select(e => new
            {
                Department = e.Key,
                AverageSalary = e.Average(emp => emp.salary),
                Employees = e.OrderByDescending(emp => emp.salary)
            })
            .OrderByDescending(dep => dep.AverageSalary)
            .FirstOrDefault();
        
        Console.WriteLine($"Highest Average Salary: {highestPaidDepartment.Department}");

        foreach (var employee in highestPaidDepartment.Employees)
        {
            Console.WriteLine($"{employee.name} {employee.salary:F2} {employee.email} {employee.age}");
        }
    }
}