public class Referee
{
    public string Name { get; set; }
    public string RefereeType { get; set; }
    public Referee()
    {
        Name = "Ahmed";
        RefereeType = "Main Referee";
    }

    // callback function
    public void Observe()
    {
        Console.WriteLine($"Referee {Name} is observing ball...");
    }

    public void Observe(Location loc)
    {
        Console.WriteLine($"Referee {Name} is observing ball...{loc}");
    }
}