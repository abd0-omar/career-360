internal class Program
{
    private static void Main(string[] args)
    {
        #region scrribles learning start
        //     Console.WriteLine("Hello, World!");
        //     var student = new ScribbleStudent() { id = 1, lname = "xd" };
        //     student.sum(new int[] { 1, 3 });
        //     student.sum(1, 3);

        //     // # anynoymous object
        //     var a = new { employeid = 3, fullname = "7amada" };
        //     // anynoymous objects are immutable
        //     // a.employeid = 3;
        //     // useful for serilizaing things for json to pass instead of creating a class
        //     // a great analogy he made, that it is like derived attributes in erd
        //     // you don't need to make a column for it as it can be calculated

        //     // Func -> returns a data type
        //     // Action -> returns void

        //     Func<int, int> func = delegate (int a)
        //     {
        //         return a;
        //     };

        //     System.Console.WriteLine(func.Invoke(3));
        //     student.calc(3, 4, delegate (int n1, int n2) { return n1 + n2; });

        //     Console.WriteLine(a);

        //     // lambda expression
        //     Func<int, int, int> func2 = (n1, n2) => n1 + n2;

        //     List<string> sts = new List<string> { "ahmed", "ali" };
        //     var f = sts.FindAll(delegate (string s)
        //    {
        //        return s == "ahmed";
        //    });

        //     // lambda expression
        //     var x = sts.FindAll((s) =>
        //        s == "ahmed"
        //    );

        //     foreach (var item in f)
        //     {
        //         System.Console.WriteLine(item);
        //     }

        //     // extension methods
        //     // closed for modification, open for extension

        //     // words count (non extension method)
        //     int word_count = ScribbleStringExtension.wordCount("hello world");
        //     System.Console.WriteLine($"word count: {word_count}");
        //     // words count (extension method)
        //     int word_count2 = "hello world".wordCount();
        //     System.Console.WriteLine($"word count: {word_count2}");

        //     // LINQ
        //     List<ScribbleStudent> students = new List<ScribbleStudent> {
        //         new ScribbleStudent {id = 1, fname = "abood", lname = "omar"},
        //         new ScribbleStudent {id = 2, fname = "bood"},
        //         new ScribbleStudent {id = 3, fname = "food"},
        //         new ScribbleStudent {id = 4, fname = "sood"},
        //     };
        //     var q1 = Enumerable.Where(students, (ScribbleStudent s) => s.id == 1);
        //     var q2 = students.Where((s) => s.id > 2);


        //     // will output the students fname only
        //     var q3 = students.Select((s) => s.fname);

        //     // anonymous object
        //     var q4 = students.Where((s) => s.id <= 2).Select((s) => new { s.fname, s.lname });
        //     foreach (var element in q4)
        //     {
        //         System.Console.WriteLine($"q4: {element}");
        //     }

        #endregion scrribles learning end


        // LINQ_Assignmet_1.subMain();
        // LINQ_Assignmet_2.subMain();
        // LINQ_Assignmet_3.subMain();
    }
}
