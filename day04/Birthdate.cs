using ErrorOr;

class Birthdate
{
    public static void ProgramLoop()
    {
        while (true)
        {
            int year = get_year();

            int month = get_month();

            int day = get_day(month);

            var today = DateTime.Today;

            DateTime birthDate = new DateTime(year, month, day);
            int years = today.Year - birthDate.Year;
            int months = today.Month - birthDate.Month;
            int days = today.Day - birthDate.Day;
            // there would be a problem that needed to be solved with mod operations, but ignore it
            Console.WriteLine($"your age is: {years} years, {months} months, {days} days");
        }
    }

    public static int get_year()
    {
        while (true)
        {
            Console.WriteLine("Please enter your year from 1980 to 2023");
            var result = _get_year();
            if (result.IsError)
            {
                Console.WriteLine($"{result.FirstError.Description}");
                continue;
            }
            return result.Value;
        }
    }

    public static ErrorOr<int> _get_year()
    {
        try
        {
            int year = int.Parse(Console.ReadLine().Trim());
            if (year < 1980 || year > 2023)
            {
                return Error.Validation(description: "Year out of range");
            }
            return year;
        }
        catch (Exception)
        {
            return Error.Validation(description: "Couldn't parse user input to int");
        }
    }

    public static int get_month()
    {
        while (true)
        {
            Console.WriteLine("Please enter your month from 1 to 12");
            var result = _get_month();
            if (result.IsError)
            {
                Console.WriteLine($"{result.FirstError.Description}");
                continue;
            }
            return result.Value;
        }
    }

    public static ErrorOr<int> _get_month()
    {
        try
        {
            int month = int.Parse(Console.ReadLine().Trim());
            if (month < 1 || month > 12)
            {
                return Error.Validation(description: "Month out of range");
            }
            return month;
        }
        catch (Exception)
        {
            return Error.Validation(description: "Couldn't parse user input to int");
        }
    }

    public static int get_day(int month)
    {
        while (true)
        {
            Console.WriteLine("Please enter your day");
            var result = _get_day(month);
            if (result.IsError)
            {
                Console.WriteLine($"{result.FirstError.Description}");
                continue;
            }
            return result.Value;
        }
    }

    public static ErrorOr<int> _get_day(int month)
    {
        try
        {
            int day = int.Parse(Console.ReadLine().Trim());
            if (month == 2)
            {
                // ignore leap year
                if (day < 1 || day > 29)
                {
                    return Error.Validation(description: "Day out of range for February");
                }
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                if (day < 1 || day > 30)
                {
                    return Error.Validation(description: $"Day out of range for month {month}");
                }
            }
            else
            {
                if (day < 1 || day > 31)
                {
                    return Error.Validation(description: $"Day out of range for month {month}");
                }
            }
            return day;
        }
        catch (Exception)
        {
            return Error.Validation(description: "Couldn't parse user input to int");
        }
    }
}
