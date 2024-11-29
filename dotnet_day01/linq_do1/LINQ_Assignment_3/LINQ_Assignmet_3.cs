class LINQ_Assignmet_3
{

    public static void subMain()
    {
        // indentation hell
        List<Student> students = new List<Student>(){
        new Student()
        {
            ID=1,
            FirstName="Ali",
            LastName="Mohammed",
            subjects=new Subject[]{ new Subject(){ Code=22,Name="EF"}, new Subject(){ Code=33,Name="UML"}}
        },
              new Student()
        {
            ID=2,
            FirstName="Mona",
            LastName="Gala",
            subjects=new Subject []
            {
                new Subject(){ Code=22,Name="EF"},
                new Subject (){ Code=34,Name="XML"},
                new Subject (){ Code=25, Name="JS"}
            }
        },             new
        Student(){
             ID=3, FirstName="Yara", LastName="Yousf", subjects=new Subject
            []
            {
                new Subject (){ Code=22,Name="EF"},
                new Subject (){ Code=25,Name="JS"}
            }},               new Student()
            {
                ID=1,
                FirstName="Ali",
                LastName="Ali",
                subjects=new Subject []{  new Subject (){ Code=33,Name="UML"}}
            },
        };
        // Query1: Display Full name and number of subjects for each student as follow  
        var q1 = students.Select((student) => new
        { FullName = $"{student.FirstName} {student.LastName}", NoOfSubjects = student.subjects.Length });


        foreach (var item in q1)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("done q1");
        // Query2: Write a query which orders the elements in the list by FirstName Descending then by LastName
        // Ascending and result of query displays only first names and last names for the elements in 
        // list as follow  
        var q2 = students.OrderByDescending((student) => student.FirstName)
        .ThenBy((student) => student.LastName).Select((student) => $"{student.FirstName} {student.LastName}");

        foreach (var item in q2)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("done q2");


    }
}
