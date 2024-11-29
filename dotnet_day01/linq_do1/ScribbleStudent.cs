public class ScribbleStudent
{
    // delegate
    public void calc(int x, int y, Func<int, int, int> func)
    {
        int f = func.Invoke(x, y);
        Console.WriteLine(f);
    }

    // init 
    // just for initialization
    // public int id { get; init; }
    // must be used in initialization
    public required int id { get; init; }
    public string fname { get; set; }
    public string lname { get; set; }

    public int sum(params int[] a)
    {
        var sum = 0;
        foreach (var element in a)
        {
            sum += element;
        }
        return sum;
    }
}