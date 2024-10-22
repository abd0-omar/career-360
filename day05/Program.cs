internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // Employee.ProgramLoop();
        Complex c1 = new(_real: 3, _img: -4);
        Complex c2 = new(_real: 5, _img: -8);
        Complex c3 = c1.Add(c2);
        Console.WriteLine(c3.Print());
    }
}
