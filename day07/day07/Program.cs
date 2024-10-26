internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public class Point
{
    int x;
    int y;

    public int X
    {
        get
        {
            return x;
        }

        set
        {
            x = value;
        }
    }
    public int Y
    {
        get
        {
            return y;
        }

        set
        {
            y = value;
        }
    }

    public Point()
    {
        x = y = 0;
        Console.WriteLine("Point def ctor");
    }

    public Point(int _x, int _y)
    {
        x = _x;
        y = _y;
        Console.WriteLine("Point 2p ctor");
    }
    public string PrintPoint()
    {
        return $"({x},{y})";
    }
}

//Composition
public class Line
{
    Point start = new Point();
    Point end = new Point();

    public Point Start
    {
        get
        {
            return start;
        }

        set
        {
            start = value;
        }
    }

    public Point End
    {
        get
        {
            return end;
        }

        set
        {
            end = value;
        }
    }

    public Line()
    {
        start.X = 0; start.Y = 0;
        end.X = 0; end.Y = 0;
        Console.WriteLine("Line def ctor");
    }
    public Line(int x1, int y1, int x2, int y2)
    {
        start.X = x1; start.Y = y1;
        end.X = x2; end.Y = y2;
        Console.WriteLine("Line 4p ctor");
    }

    public string PrintLine()
    {
        return $"Line start {start.PrintPoint()} , End {end.PrintPoint()}";
    }
}

//Composition
public class Rectangle
{
    Point ul;
    Point lr;

    public Point Ul
    {
        get
        {
            return ul;
        }

        set
        {
            ul = value;
        }
    }

    public Point Lr
    {
        get
        {
            return lr;
        }

        set
        {
            lr = value;
        }
    }

    public Rectangle()
    {
        ul = new Point();
        lr = new Point();
        Console.WriteLine("Rect def ctor");
    }

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        ul = new Point(x1, y1);
        lr = new Point(x2, y2);
        Console.WriteLine("Rect 4p ctor");
    }
    public string PrintRect()
    {
        return $"Line start {ul.PrintPoint()} , End {lr.PrintPoint()}";
    }
}

///association / aggregation
public class Triangle
{
    Point p1;
    Point p2;
    Point p3;

    public Point P1
    {
        get
        {
            return p1;
        }

        set
        {
            p1 = value;
        }
    }

    public Point P2
    {
        get
        {
            return p2;
        }

        set
        {
            p2 = value;
        }
    }

    public Point P3
    {
        get
        {
            return p3;
        }

        set
        {
            p3 = value;
        }
    }

    public Triangle()
    {
        p1 = null;
        p2 = null;
        p3 = null;
        Console.WriteLine("Tri def ctor");
    }
    public Triangle(Point _p1, Point _p2, Point _p3)
    {
        p1 = _p1;
        p2 = _p2;
        p3 = _p3;
    }

    //=> composition
    public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
    {
        p1 = new Point(x1, y1);
        p2 = new Point(x2, y2);
        p3 = new Point(x3, y3);

        p1.X = x1;
        p1.Y = y1;
        p2.X = x2;
        p2.Y = y2;
        p3.X = x3;
        p3.Y = y3;
    }
}

public class Circle
{
    Point center;
    int radius;

    public Point Center
    {
        get
        {
            return center;
        }

        set
        {
            center = value;
        }
    }

    public int Radius
    {
        get
        {
            return radius;
        }

        set
        {
            radius = value;
        }
    }

    public Circle()
    {
        center = new Point();
        radius = 0;
    }

    public Circle(Point _center, int _radius)
    {
        center = _center;
        radius = _radius;
    }
    public Circle(int x1, int y1, int _radius)
    {
        center = new Point(x1, y1);
        radius = _radius;
    }
}

public class Student
{
    #region Auto-Properties
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public float Grade { get; set; }
    #endregion

    #region Constructors
    public Student()
    {
        Id = 1;
        Name = "Habeba";
        Age = 20;
        Grade = 3.5F;
    }

    public Student(int _id, string _name, int _age, float _grade)
    {
        Id = _id;
        Name = _name;
        Age = _age;
        Grade = _grade;
    }
    #endregion

    #region Print
    public string Print()
    {
        return $"{Id}:{Name}:{Age}:{Grade}";
    }
    #endregion
}


public class Employee
{
    #region Data Fields
    private int id;
    private string name;
    private int age;
    private decimal salary;
    #endregion

    #region Properties
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }
    #endregion

    #region Constructors
    public Employee()
    {
        id = 0;
        name = "Unknown";
        age = 0;
        salary = 0.0M;
    }

    public Employee(int _id, string _name, int _age, decimal _salary)
    {
        id = _id;
        name = _name;
        age = _age;
        salary = _salary;
    }
    #endregion

    #region Print
    public string Print()
    {
        return $"{id}:{name}:{age}:{salary}";
    }
    #endregion
}
