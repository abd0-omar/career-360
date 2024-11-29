class LINQ_Assignmet_1
{
    public static void subMain()
    {
        List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };
        // Query1: Display numbers without any repeated Data and sorted  
        var q1 = numbers.Order().Distinct();
        foreach (var item in q1)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("done q1");
        // Query2: using Query1  result and show each number and it’s multiplication  
        var q2 = q1.Select((num) => new { Number = num, Multiply = num * num });
        foreach (var item in q2)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("done q2");
    }
}
