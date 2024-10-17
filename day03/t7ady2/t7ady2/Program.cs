internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // implicity start
        // implicit conversion
        ImplicitConversionExample impliceet = new(3);
        double toDouble = impliceet.ToDouble();
        Console.WriteLine(toDouble.GetType()); // System.Double
        // implicit reference conversion
        Animal animal = new();
        Dog dog = new();
        Animal Animal2 = dog;
        // implicit end
        // explicit start
        ExplicitConversionExample expliceet = new(3.3);
        expliceet.Display(); // System.Int32
        // explicit end
        Person person = new(_age: 3, _name: "wow");
        Console.WriteLine(person.name);
        Console.WriteLine(person.age);
        // Student student = new(_age: -1, _name: "zola", _student_id: "ideeznuts");
        Student stu = Student.convert_person_to_student(person);
        Console.WriteLine(stu.name);
        Console.WriteLine(stu.age);
        Console.WriteLine(stu.student_id);
    }
}

// implicit conversion start

public class ImplicitConversionExample
{
    int IntValue;

    public ImplicitConversionExample(int newIntValue)
    {
        IntValue = newIntValue;
    }

    public double ToDouble()
    {
        double result = IntValue;
        return result;
    }
}

// implicit reference conversion
public class Animal
{

}

public class Dog : Animal
{

}

// implicit conversion end

// explicit conversion start
public class ExplicitConversionExample
{
    double DoubleValue;

    public ExplicitConversionExample(double newDobuleValue)
    {
        DoubleValue = newDobuleValue;
    }

    private int ToInt()
    {
        int result = Convert.ToInt32(DoubleValue);
        return result;
    }

    public void Display()
    {
        try
        {
            int result = ToInt();
            Console.WriteLine(result.GetType());
        }
        catch (OverflowException)
        {
            Console.WriteLine("couldn't convert to int");
            return;
        }
    }


}

// explicit custom type conversion
class Person
{
    public string name { get; }
    public int age { get; }

    public Person(string _name, int _age)
    {
        name = _name;
        age = _age;
    }
}

class Student
{
    public string name { get; }
    public int age { get; }
    public string student_id { get; }

    public Student(string _name, int _age, string _student_id)
    {
        name = _name;
        age = _age;
        student_id = _student_id;
    }

    public static Student convert_person_to_student(Person person)
    {
        Student student = new(_age: person.age, _name: person.name, _student_id: "defaulting to the default value which is default by default");
        return student;
    }
}

// explicit conversion end