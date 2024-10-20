using ErrorOr;

class ArrayOperations
{
    public static void ProgramLoop()
    {
        Console.WriteLine("you only get one chance to get it right, there is no while loops here");
        Console.WriteLine("I trust you-ish");
        Console.WriteLine("enter array size");
        var lenResult = GetNumber();
        if (lenResult.IsError)
        {
            Console.WriteLine("invalid input");
            Console.WriteLine($"{lenResult.FirstError.Description}");
            return;
        }
        var len = lenResult.Value;
        Console.WriteLine("enter array elements");

        var arrayResult = GetArray(len);
        if (arrayResult.IsError)
        {
            Console.WriteLine("invalid input");
            Console.WriteLine($"{arrayResult.FirstError.Description}");
            return;
        }
        int[] array = arrayResult.Value;
        // assume the user is smart
        // if (array.Length > 0) 
        // int min = int.MaxValue;
        // int max = int.MinValue;
        int min = array[0];
        int max = array[0];
        for (int i = 1; i < len; i++)
        {
            var curElement = array[i];
            if (curElement < min)
            {
                min = array[i];
            }
            else
            {
                if (curElement > max)
                {
                    max = array[i];
                }
            }
        }

        Console.WriteLine($"min: {min}");
        Console.WriteLine($"max: {max}");
        // sort
        // insertion sort
        for (int i = 1; i < len; i++)
        {
            int key = i;
            for (int j = i - 1; j >= 0; j--)
            {
                //          j   i
                // a[key] < a[j] shift
                // shift: a[j+1] = a[j]
                // 2, 4, 8, 10, 5
                // 2, 4, 8, 10, 10
                // 2, 4, 8, 8, 10
                // 2, 4, 5, 8, 10
                // 
                if (array[key] < array[j])
                {
                    array[j + 1] = array[j];
                }
                else
                {
                    array[j + 1] = array[key];
                    break;
                }
            }
        }
        // sorted
        Console.WriteLine("sorted array: ");
        for (int i = 0; i < len; i++)
        {
            if (i == 0)
            {
                Console.Write($"{array[i]}");
            }
            else
            {

                Console.Write($", {array[i]}");
            }
        }
        Console.WriteLine();
        // search
        // it's sorted so binary search it is, or I'll be like this guy
        // https://www.youtube.com/watch?v=ig-dtw8Um_k
        Console.WriteLine("Enter the number you want to search on");
        var targetResult = GetNumber();
        if (targetResult.IsError)
        {
            Console.WriteLine("you gotta do it all again Sisyphus");
            Console.WriteLine(targetResult.FirstError.Description);
            return;
        }
        int target = targetResult.Value;
        int l = 0;
        int r = len - 1;
        int ans = -1;
        while (l < r)
        {
            int mid = l + (r - l) / 2;
            if (array[mid] == target)
            {
                Console.WriteLine($"found it in less than or equal log{len}");
                ans = mid;
                break;
            }
            else if (array[mid] > target)
            {
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }
        if (ans != -1)
        {
            Console.WriteLine($"found at {ans} zero-indexed");
        }
        else
        {
            Console.WriteLine($"what are you searching for is not here traveler");
        }
    }

    public static ErrorOr<int> GetNumber()
    {
        try
        {

            int len = int.Parse(Console.ReadLine().Trim());
            return len;
        }
        catch (Exception)
        {
            return Error.Validation(description: "invalid len");
        }
    }

    public static ErrorOr<int[]> GetArray(int len)
    {
        int[] array = new int[len];
        for (int i = 0; i < len; i++)
        {
            Console.WriteLine($"enter the {i} element: ");
            try
            {
                int element = int.Parse(Console.ReadLine().Trim());
                array[i] = element;
            }
            catch (Exception)
            {
                return Error.Validation(description: "couldn't parse input to int");
            }
        }
        return array;
    }
}
