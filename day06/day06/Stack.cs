using ErrorOr;

public class Stack
{
    readonly int[] arr;
    int tos;
    readonly int size;
    private static int counter = 0;
    public static int GetCounter()
    {
        return counter;
    }
    public Stack(int _size)
    {
        counter++;
        tos = 0;
        size = _size;
        arr = new int[size];
    }
    public bool Push(int number)
    {
        if (!IsFull())
        {
            arr[tos] = number;
            tos++;
            return true;
        }
        else
        {
            Console.WriteLine("FULL!!!");
            return false;
        }
    }

    public ErrorOr<int> Pop()
    {
        if (!IsEmpty())
        {
            tos--;
            int result = arr[tos];
            return result;
        }
        else
        {
            return Error.Failure("stack already empty");
        }
    }

    public bool IsFull()
    {
        return tos == size;
    }

    public bool IsEmpty()
    {
        return tos == 0;
    }

    public ErrorOr<int> Peek()
    {
        if (!IsEmpty())
        {
            return arr[tos - 1];
        }
        else
        {
            return Error.Failure("stack is empty");
        }
    }
}
