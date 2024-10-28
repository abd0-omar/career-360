internal class Program
{
    private static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");
        // Duration duration = new Duration(3665);
        // Console.WriteLine(duration.ToString());

        // Duration duration2 = new Duration(0, 125, 0);
        // Console.WriteLine(duration2.ToString());
        var resultPoint1 = Point3D.ReadPoint("point1");
        if (resultPoint1.IsError)
        {
            Console.WriteLine($"{resultPoint1.FirstError.Description}");
            return;
        }

        var resultPoint2 = Point3D.ReadPoint("point2");
        if (resultPoint2.IsError)
        {
            Console.WriteLine($"{resultPoint2.FirstError.Description}");
            return;
        }

        var points = new Point3D[3];
        for (int i = 0; i < 3; i++)
        {
            var resultPoint = Point3D.ReadPoint($"point{i}");
            if (resultPoint.IsError)
            {
                Console.WriteLine($"{resultPoint.FirstError.Description}");
                return;
            }
            points[i] = resultPoint.Value;
        }
        foreach (var point in points)
        {
            Console.WriteLine(point.ToString());
        }
    }

}
