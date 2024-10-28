using ErrorOr;

class Point3D
{
    int x;
    int y;
    int z;

    public Point3D(int _x, int _y, int _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }

    public override string ToString()
    {
        return $"Point Coordinates: ({x}, {y}, {z})";
    }

    public static explicit operator string(Point3D p)
    {
        return p.ToString();
    }

    public static ErrorOr<int> takeIntInput(string name)
    {
        Console.WriteLine($"{name}: ");
        if (!int.TryParse(Console.ReadLine().Trim(), out int result))
        {
            return Error.Validation("Invalid input, please enter an integer.");
        }
        return result;
    }

    public static ErrorOr<Point3D> ReadPoint(string pointName)
    {
        Console.WriteLine($"Enter {pointName}:");

        var xResult = takeIntInput("x");
        if (xResult.IsError) return xResult.Errors[0];

        var yResult = takeIntInput("y");
        if (yResult.IsError) return yResult.Errors[0];

        var zResult = takeIntInput("z");
        if (zResult.IsError) return zResult.Errors[0];

        return new Point3D(xResult.Value, yResult.Value, zResult.Value);
    }
}
