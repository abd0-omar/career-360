using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // FOOTBALL
        /*
        Console.WriteLine("Hello, World!");
        FootballBall football1 = new FootballBall { Id = 1, BallName = "Adidas1", Location = new Location() };

        Player p1_1 = new Player { Name = "Ahmed", Team = "Team1", Number = 10 };
        Player p1_2 = new Player { Name = "Ali", Team = "Team1", Number = 11 };
        Player p1_3 = new Player { Name = "Osama", Team = "Team1", Number = 12 };
        Player p1_4 = new Player { Name = "Khattab", Team = "Team1", Number = 13 };

        Player p2_1 = new Player { Name = "Saeed", Team = "Team2", Number = 10 };
        Player p2_2 = new Player { Name = "Ibra", Team = "Team2", Number = 11 };
        Player p2_3 = new Player { Name = "Marwan", Team = "Team2", Number = 12 };
        Player p2_4 = new Player { Name = "Ziad", Team = "Team2", Number = 13 };

        Referee referee1 = new Referee();

        football1.BallLocationChanged += p1_1.Run;
        football1.BallLocationChanged += p1_2.Run;
        System.Console.WriteLine("wowoowowo");
        football1.BallLocationChanged += referee1.Observe;
        football1.BallLocationChanged += (Location loc) => Console.WriteLine("Start!!!");

        football1.Location = new Location { X = 4, Y = 5, Z = 6 };

        football1.BallLocationChanged -= p1_1.Run;

        football1.BallLocationChanged += p1_4.Run;
        football1.BallLocationChanged += p2_4.Run;

        football1.Location = new Location { X = 44, Y = 55, Z = 56 };
        */
        BankAccount account1 =
            new BankAccount { AccountNo = 123, Name = "Marwan", Balance = 5000 };

        BankAgent agent1 = new BankAgent(); // el3areef 3abdelaziz

        //subcribe to event
        account1.UnderBalanced += agent1.WarnBankAccount;
        account1.UnderBalanced += BlackListAccounts.AddToBlackList;
        //
        account1.Credit(5020);
        //
        // no warnings from the bank because delta is less than 100, the delta in the bankaccount class
        // and the condition of the delta < 100 in the subscribers functions 
    }
}

// bank

public class BankAccount
{
    public int AccountNo { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }

    public BankAccount()
    {
        AccountNo = 1234;
        Name = "Abdo";
        Balance = 5000;
    }
    //
    public bool Debit(decimal _amount)
    {
        if (_amount > 0)
        {
            Balance += _amount;
            return true;
        }
        return false;
    }

    public bool Credit(decimal _amount)
    {
        var delta = _amount - Balance;
        if (Balance > _amount)
        {
            Balance -= _amount;
            return true;
        }
        else
        {
            Balance -= _amount;
            // fire Event
            OnUnderBalanced(new UnderBalancedEventArgs { Delta = delta });
            return false;
        }
    }
    //
    public override string ToString()
    {
        return $"{AccountNo}:{Name}->{Balance}";
    }

    //Event Framework ♥
    public event EventHandler<UnderBalancedEventArgs>? UnderBalanced;
    protected virtual void OnUnderBalanced(UnderBalancedEventArgs e)
    {
        //fire Event Here
        UnderBalanced?.Invoke(this, e);
    }
    //
}

public class UnderBalancedEventArgs : EventArgs
{
    public decimal Delta { get; set; }
    public DateTime TimeStamp { get; } = DateTime.Now;

}

public class BankAgent
{
    public string AgentName { get; set; }
    public int AgentId { get; set; }

    public BankAgent()
    {
        AgentId = 123;
        AgentName = "el3areef 3abdelaziz";
    }

    //callback method
    //public void WarnBankAccount(object sender, EventArgs e)
    //{
    //    if (sender is BankAccount ba)
    //    {
    //        Console.WriteLine($"Agent {AgentName} warns {ba.Name} from under balanced!!!");
    //    }
    //}

    //callback method
    public void WarnBankAccount(object sender, UnderBalancedEventArgs e)
    {
        if (sender is BankAccount ba && e.Delta > 100)
        {
            Console.WriteLine($"Ajent {AgentName} warns {ba.Name} from under balanced!!!");
        }
    }
}

public static class BlackListAccounts
{
    public static List<string> BlackListNames { get; }
    = new List<string>();

    //call back function
    //public static void AddToBlackList(object sender, EventArgs e)
    //{
    //    var ba = sender as BankAccount;
    //    //if (e is UnderBalancedEventArgs er && er.Delta>100)
    //    {
    //        Console.WriteLine($"Proceed to add {ba.Name} into black list");
    //        BlackListNames.Add(ba.Name); 
    //    }
    //}

    public static void AddToBlackList(object sender, UnderBalancedEventArgs e)
    {
        var ba = sender as BankAccount;
        if (e.Delta > 100)
        {
            Console.WriteLine($"Proceed to add {ba.Name} into black list");
            BlackListNames.Add(ba.Name);
        }
    }
    public static string ReviewBlackListNames()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string s in BlackListNames)
        {
            sb.Append(s);
            sb.Append(Environment.NewLine);
        }
        return sb.ToString();
    }
}

public class EnterpriseBankAccount : BankAccount
{

    public bool Transfer(BankAccount employee, decimal _salary)
    {
        var delta = _salary - this.Balance;
        if (this.Balance > _salary)
        {
            employee.Balance += _salary;
            this.Balance -= _salary;
            return true;
        }
        else
        {
            employee.Balance += _salary;
            this.Balance -= _salary;
            //event firing
            OnUnderBalanced(new UnderBalancedEventArgs { Delta = delta });
            return false;
        }
    }
}