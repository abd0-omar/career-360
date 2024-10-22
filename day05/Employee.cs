class Employee
{
    #region Notes
    //any data inside class/struct -> member  field/function[method]
    //member can be accessed by object name
    //public:member can be accessed inside/outside class/struct
    //private[default]:member can be accessed inside class/struct ONLY
    #endregion

    #region Data Fields
    //Data fields
    int id;
    string name;
    int age;
    decimal salary; //->getter only
                    //password  -> setter only
    #endregion

    #region Setters & getters MUST be public   [Gates]
    //caller -> e2         22
    public void SetId(int _id)
    {
        /*caller e2*/
        id = _id;
    }
    //caller e2
    public int GetId()
    {
        return /*caller e2*/id;
    }
    public void SetName(string _name)
    {
        name = _name;
    }
    public string GetName()
    {
        return name;
    }
    public void SetAge(int _age)
    { age = _age; }

    public int GetAge()
    {
        return age;
    }
    public void SetSalary(decimal _salary)
    {
        if (_salary >= 5000 && _salary <= 10_000)
        {
            salary = _salary;
        }
        else
        {
            salary = 5000;
        }
    }
    public decimal GetSalary()
    {
        return salary;
    }
    #endregion

    #region Function to print Object    SOLID
    //e1.PrintV1()  
    public void PrintV1()
    {
        Console.WriteLine(/*caller*/id);
        Console.WriteLine(/*caller*/name);
        Console.WriteLine(/*caller*/age);
        Console.WriteLine(/*caller*/salary);
    }
    //RECOMMENDED
    public string PrintV2()
    {
        return $"{id}:{name}:{age}:{salary}";
    }
    #endregion

    public static void ProgramLoop()
    {

        Employee[] employees = new Employee[10];
        int index;
        string flag;
        do
        {
            do
            {
                Console.WriteLine("Choose index 0->9");
                index = int.Parse(Console.ReadLine());
            } while (index < 0 || index > 9);

            employees[index] = new Employee();

            Console.WriteLine("Enter id");
            employees[index].SetId(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter name");
            employees[index].SetName(Console.ReadLine());
            do
            {
                Console.WriteLine("Enter age");
                employees[index].SetAge(int.Parse(Console.ReadLine()));
            }
            while (employees[index].GetAge() < 18 || employees[index].GetAge() > 60);

            Console.WriteLine("Enter salary");
            employees[index].SetSalary(decimal.Parse(Console.ReadLine()));

            Console.WriteLine("Continue , yes or no");
            flag = Console.ReadLine();

        }
        while (flag.ToLower() == "yes");

        for (int i = 0; i < employees.Length; i++)
        {
            //print enetered employees ONLY 
            if (employees[i] is not null)
            {
                Console.WriteLine(employees[i].PrintV2());
            }
        }
    }
}
