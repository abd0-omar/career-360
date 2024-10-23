using ErrorOr;
// circual queue
public class Queue
{
    private readonly int[] arr;
    private int front;
    private int rear;
    private int count;
    private readonly int size;
    private static int counter = 0;

    public static int GetCounter()
    {
        return counter;
    }

    public Queue(int _size)
    {
        counter++;
        front = 0;
        rear = 0;
        count = 0;
        size = _size;
        arr = new int[size];
    }

    public bool Enqueue(int number)
    {
        if (!IsFull())
        {
            arr[rear] = number;
            rear = (rear + 1) % size;
            count++;
            return true;
        }
        else
        {
            Console.WriteLine("FULL!!!");
            return false;
        }
    }

    public ErrorOr<int> Dequeue()
    {
        if (!IsEmpty())
        {
            int result = arr[front];
            front = (front + 1) % size;
            count--;
            return result;
        }
        else
        {
            return Error.Failure("queue already empty");
        }
    }

    public ErrorOr<int> Peek()
    {
        if (!IsEmpty())
        {
            return arr[front];
        }
        else
        {
            return Error.Failure("queue is empty");
        }
    }

    public bool IsFull()
    {
        return count == size;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }
}