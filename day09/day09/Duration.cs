using System.Text;

public class Duration
{
    int hours;
    int minutes;
    int seconds;

    public Duration(int _seconds)
    {
        hours = _seconds / (60 * 60);
        // remove full hours from seconds
        _seconds %= 60 * 60;
        minutes = _seconds / 60;
        // remove a minute from seconds
        seconds = _seconds % 60;
    }

    public Duration(int _hours, int _seconds, int _minutes)
    {
        // user may construct with "wrong format"
        // like more than 60 seconds and etc.
        // if _seconds > 60  and so on
        hours = _hours;
        minutes = _minutes;
        seconds = _seconds;
    }
    public override string ToString()
    {
        var result = new StringBuilder();
        if (hours > 0)
        {
            result.Append($"Hours: {hours}, ");
        }
        if (minutes > 0)
        {
            result.Append($"minutes: {minutes}, ");
        }

        if (seconds > 0)
        {
            result.Append($"seconds: {seconds}");
        }
        return result.ToString();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Duration other)
        {
            return false;
        }

        return hours == other.hours && minutes == other.minutes && seconds == other.seconds;
    }

    public static Duration operator +(Duration d1, Duration d2)
    {
        return new Duration(d1.hours + d2.hours, d1.minutes + d2.minutes, d1.seconds + d2.seconds);
    }

    public static Duration operator +(Duration d, int secondsAdd)
    {
        return new Duration(d.hours, d.minutes, d.seconds + secondsAdd);
    }

    public static Duration operator +(int secondsAdd, Duration d)
    {
        return d + secondsAdd;
    }

    public static Duration operator ++(Duration d)
    {
        // if it's 60, return to 0 and add 1 to hours
        if (d.minutes == 59)
        {
            return new Duration(d.hours + 1, 0, d.seconds);
        }
        else
        {
            return new Duration(d.hours, d.minutes + 1, d.seconds);
        }
    }

    public static Duration operator --(Duration d)
    {
        // if it's 0, underflow to 59 and decrease hours if it exists
        if (d.minutes == 0)
        {
            if (d.hours < 1)
            {
                throw new Exception();
            }
            else
            {
                return new Duration(d.hours - 1, 59, d.seconds);
            }
        }
        else
        {
            return new Duration(d.hours, d.minutes - 1, d.seconds);
        }
    }

    private int ToSeconds()
    {
        return hours * 60 * 60 + minutes * 60 + seconds;
    }

    public static bool operator >(Duration d1, Duration d2)
    {
        return d1.ToSeconds() > d2.ToSeconds();
    }

    public static bool operator <(Duration d1, Duration d2)
    {
        return d1.ToSeconds() < d2.ToSeconds();
    }

    public static bool operator >=(Duration d1, Duration d2)
    {
        return d1.ToSeconds() >= d2.ToSeconds();
    }

    public static bool operator <=(Duration d1, Duration d2)
    {
        return d1.ToSeconds() <= d2.ToSeconds();
    }
}