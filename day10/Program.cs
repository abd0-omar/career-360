using System.Globalization;

namespace day10
{
    public enum Gender
    {
        Male,
        Female
    }

    [Flags]
    public enum SecurityLevel : byte
    // instead of doing Guest = 0b10
    {
        Guest = 1,
        Developer = 2,
        Secretary = 4,
        DBA = 8,
        FullPermissions = Guest | Developer | Secretary | DBA

    }
    public static class SecurityLevelExtension
    {
        public static SecurityLevel ParseSecurityLevel(string input)
        {
            if (Enum.TryParse(input, ignoreCase: true, out SecurityLevel securityLevel))
            {
                return securityLevel;
            }
            throw new ArgumentException("wrong security level");
        }


        public class HireDate : IComparable
        {
            public int Day { get; set; }
            public int Month { get; set; }
            public int Year { get; set; }

            public HireDate(int day = 1, int month = 1, int year = 2000)
            {
                Day = day;
                Month = month;
                Year = year;
            }

            public override string ToString()
            {
                return $"{Day}/{Month}/{Year}";
            }

            public int CompareTo(object obj)
            {
                if (obj is HireDate other)
                    return new DateTime(Year, Month, Day).CompareTo(new DateTime(other.Year, other.Month, other.Day));
                throw new Exception("obj is not HireDate");
            }
        }

        public class Employee : IComparable
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public SecurityLevel SecurityLevel { get; set; }
            public decimal Salary { get; set; }
            public HireDate HireDate { get; set; }
            public Gender Gender { get; set; }

            public Employee(int id, string name, SecurityLevel securityLevel, decimal salary, HireDate hireDate, Gender gender)
            {
                Id = id;
                Name = name;
                SecurityLevel = securityLevel;
                Salary = salary;
                HireDate = hireDate;
                Gender = gender;
            }

            public override string ToString()
            {
                return $"Id: {Id}, Name: {Name}, Security Level: {SecurityLevel}, Salary: {Salary}, Hire Date: {HireDate}, Gender: {Gender}";
            }

            // for sorting
            // sort by hiredate
            public int CompareTo(object obj)
            {
                if (obj is Employee other)
                    return HireDate.CompareTo(other.HireDate);
                throw new ArgumentException("Object is not Employee");
            }

            // Static method to parse gender from user input
            public static Gender ParseGender(string input)
            {
                if (Enum.TryParse(input, true, out Gender gender))
                    return gender;
                throw new ArgumentException("Only Male and Female are allowed.");
            }
        }


        internal class Program
        {
            private static void Main(string[] args)
            {
                Employee[] employees = new Employee[3];

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"Enter Employee {i + 1}:");

                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Security Level (Guest, Developer, Secretary, DBA, FullPermissions): ");
                    SecurityLevel securityLevel = SecurityLevelExtension.ParseSecurityLevel(Console.ReadLine());

                    Console.Write("Salary: ");
                    decimal salary = decimal.Parse(Console.ReadLine());

                    Console.Write("Hire Date (Day Month Year): ");
                    string[] hireDateParts = Console.ReadLine().Split(' ');
                    int day = int.Parse(hireDateParts[0]);
                    int month = int.Parse(hireDateParts[1]);
                    int year = int.Parse(hireDateParts[2]);
                    HireDate hireDate = new HireDate(day, month, year);

                    Console.Write("Gender: ");
                    Gender gender = Employee.ParseGender(Console.ReadLine());

                    employees[i] = new Employee(id, name, securityLevel, salary, hireDate, gender);
                }

                // sort employees by hire date
                Array.Sort(employees);

                foreach (var emp in employees)
                    Console.WriteLine(emp);
            }
        }
    }
}