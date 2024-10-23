internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Stack stack = new(5);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine(stack.Pop().Value);
        Console.WriteLine(stack.Peek().Value);

        Queue queue = new(5);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Console.WriteLine(queue.Dequeue().Value);
        Console.WriteLine(queue.Peek().Value);
    }
}
