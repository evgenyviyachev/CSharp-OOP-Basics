using System;
using System.Text;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public virtual string FirstName
    {
        get
        {
            return this.firstName;
        }
        protected set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }

            this.firstName = value;
        }
    }

    public virtual string LastName
    {
        get
        {
            return this.lastName;
        }
        protected set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            this.lastName = value;
        }
    }
}

public class Student : Human
{
    private string facultyNum;

    public Student(string firstName, string lastName, string facultyNum)
        : base(firstName, lastName)
    {
        this.FacultyNum = facultyNum;
    }

    public override string FirstName
    {
        get
        {
            return base.FirstName;
        }
        protected set
        {
            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }

            base.FirstName = value;
        }
    }

    public override string LastName
    {
        get
        {
            return base.LastName;
        }

        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }

            base.LastName = value;
        }
    }

    public string FacultyNum
    {
        get
        {
            return this.facultyNum;
        }
        private set
        {
            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsLetterOrDigit(value[i]))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
            }

            this.facultyNum = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("First Name: ").Append(this.FirstName).Append(Environment.NewLine)
            .Append("Last Name: ").Append(this.LastName).Append(Environment.NewLine)
            .Append("Faculty number: ").Append(this.FacultyNum).Append(Environment.NewLine);

        return sb.ToString();
    }
}

public class Worker : Human
{
    private double salary;
    private double workingHours;

    public Worker(string firstName, string lastName, double salary, double workingHours)
        : base(firstName, lastName)
    {
        this.Salary = salary;
        this.WorkingHours = workingHours;
    }

    public override string LastName
    {
        get
        {
            return base.LastName;
        }

        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }

            base.LastName = value;
        }
    }

    public double Salary
    {
        get
        {
            return this.salary;
        }
        private set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.salary = value;
        }
    }

    public double WorkingHours
    {
        get
        {
            return this.workingHours;
        }
        private set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workingHours = value;
        }
    }

    private double CalculateSalaryPerHour()
    {
        return (double)this.Salary / (this.WorkingHours * 5);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("First Name: ").Append(this.FirstName).Append(Environment.NewLine)
            .Append("Last Name: ").Append(this.LastName).Append(Environment.NewLine)
            .Append("Week Salary: ").Append($"{this.Salary:F2}").Append(Environment.NewLine)
            .Append("Hours per day: ").Append($"{this.WorkingHours:F2}").Append(Environment.NewLine)
            .Append("Salary per hour: ").Append($"{this.CalculateSalaryPerHour():F2}").Append(Environment.NewLine);

        return sb.ToString();
    }
}

public class Mankind
{
    public static void Main()
    {
        string[] studentData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] workerData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            string studentFirstName = studentData[0];
            string studentLastName = studentData[1];
            string studentFacultyNumber = studentData[2];

            string workerFirstName = workerData[0];
            string workerLastName = workerData[1];
            double workerSalary = double.Parse(workerData[2]);
            double workerWorkingHours = double.Parse(workerData[3]);

            Student student = new Student(studentFirstName, studentLastName, studentFacultyNumber);
            Worker worker = new Worker(workerFirstName, workerLastName, workerSalary, workerWorkingHours);

            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}