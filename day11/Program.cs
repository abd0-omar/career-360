internal class Program
{
    private static void Main(string[] args)
    {
        var employees = Repository.Employees;

        var filteredEmployees = Filtartion.FilterBySalary(employees, 4200);
        foreach (var emp in filteredEmployees)
        {
            Console.WriteLine(emp.ToString());
        }

        Console.WriteLine("----------------");

        var filteredEmployeesDelegate = Filtartion.FilterBySalaryDelegate(employees, 4200, (employee, salary) => employee.Salary >= 4200);
        foreach (var emp in filteredEmployees)
        {
            Console.WriteLine(emp.ToString());
        }

        // func returns a value, with last input parameter being the return type
        // Action returns void
        // Predicate takes one input parameter and returns a boolean

        Func<int, int, int> myFunc = (x, y) => x + y;
        var sum = myFunc(3, 4);

        // https://www.youtube.com/watch?v=SYEMmzpxKUU&t=2484s
        Action<string> actionFelPotential = (sayHelloTo) => Console.WriteLine($"Hello, {sayHelloTo}!");
        actionFelPotential("3alam");

        Predicate<int> isEven = (x) =>
        {
            if (x % 2 == 0)
            {
                return true;
            }
            return false;
        };
        if (isEven(4))
        {
            Console.WriteLine("Correct!");
        }
    }
}

public class Employee
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public int DeptId { get; set; }

    public override string ToString()
    {
        return $"{Id}:{Name}:{Age}:{Salary}:{DeptId}";
    }
}

public static class Repository
{
    public static List<Employee> Employees { get; set; }
    = new List<Employee>()
    {
            new Employee{Id=1,Name="Sara",Age=20,Salary=10234,DeptId=10},
            new Employee{Id=2,Name="Osama",Age=30,Salary=9234,DeptId=20},
            new Employee{Id=3,Name="Aya",Age=29,Salary=8234,DeptId=20},
            new Employee{Id=4,Name="Lara",Age=28,Salary=7234,DeptId=30},
            new Employee{Id=5,Name="Saeed",Age=27,Salary=6234,DeptId=30},
            new Employee{Id=6,Name="Mariem",Age=26,Salary=5234,DeptId=20},
            new Employee{Id=7,Name="Ahmed",Age=25,Salary=4234,DeptId=20},
            new Employee{Id=8,Name="Eman",Age=24,Salary=3234,DeptId=10},
            new Employee{Id=9,Name="Khatab",Age=23,Salary=2234,DeptId=10},
            new Employee{Id=10,Name="Ali",Age=22,Salary=1234,DeptId=10}
    };
}

public static class Filtartion
{
    // filter without delegate
    public static List<Employee> FilterBySalary(List<Employee> employees, decimal salary)
    {
        var result = new List<Employee>();
        foreach (var employee in employees)
        {
            if (employee.Salary >= salary)
            {
                result.Add(employee);
            }
        }
        return result;
    }

    // filter by delegate
    public static List<Employee> FilterBySalaryDelegate(List<Employee> employees, decimal salary, MyDelegate myDelegate)
    {
        var result = new List<Employee>();
        foreach (var employee in employees)
        {
            if (myDelegate(employee, salary))
            {
                result.Add(employee);
            }
        }
        return result;
    }
}

public delegate bool MyDelegate(Employee employee, decimal salary);