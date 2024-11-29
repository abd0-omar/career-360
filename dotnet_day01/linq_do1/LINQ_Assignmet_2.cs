class LINQ_Assignmet_2
{
    public static void subMain()
    {
        string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

        // Query1: Select names with length equal 3.  
        var q1 = names.Where((name) => name.Length == 3);

        foreach (var item in q1)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("done q1");

        // Query2: Select names that contains “a” letter (Capital or Small )then sort them by length  
        var q2 = names.Where((name) => name.ToLower().Contains('a'));

        foreach (var item in q2)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("done q2");

        // Query3: Display the first 2 names  

        var q3 = names.Take(2);

        foreach (var item in q3)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("done q3");
    }
}