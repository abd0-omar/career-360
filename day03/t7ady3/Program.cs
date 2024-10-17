internal class Program
{
    private static void Main(string[] args)
    {
        // part 1
        Console.WriteLine("Hello, World!");
        int x = 10;
        increase_value_value(x);
        Console.WriteLine(x);
        Person person = new("john", 16);
        // ChangePersonDetails(person);
        ChangePersonDetails(ref person);
        Console.WriteLine(person.name);
        Console.WriteLine(person.age);
        // part 2
        increase_value(ref x);
        Console.WriteLine(x);
        double result;
        DivideNumbers(a: 10, b: 2, out result);
        Console.WriteLine(result);
        Person person2;
        CreatePerson(out person2);
        Console.WriteLine(person2.name);
        Console.WriteLine(person2.age);
    }
    // pass by reference
    public static void increase_value(ref int x)
    {
        x += 10;
    }
    // pass by value
    public static void increase_value_value(int x)
    {
        x += 10;
    }
    public static void ChangePersonDetails(ref Person person)
    {
        person.name = "3owadeen";
        // 2 because he's "3owadeen"
        // other examples m7mdeen, a7mdeen, hasaneen
        // and there is also the plural ones like 8wayeesh..etc.
        person.age = 2;
    }

    public static void DivideNumbers(int a, int b, out double result)
    {
        result = (double)a / b;
    }

    static void CreatePerson(out Person person)
    {
        person = new Person("Alice", 25);
    }

    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }

        public Person(string _name, int _age)
        {
            name = _name;
            age = _age;
        }

    }
}