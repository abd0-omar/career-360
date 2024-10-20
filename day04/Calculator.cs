class Calculator
{
    public static void ProgramLoop()
    {
        while (true)
        {
            double num1 = GetNumber("Please enter #1:");
            double num2 = GetNumber("Please enter #2:");
            char operation = GetOperator();

            double result = PerformCalculation(num1, num2, operation);
            Console.WriteLine($"{num1} {operation} {num2} = {result}");

            Console.WriteLine("Continue ??? y or n");
            string choice = Console.ReadLine().Trim().ToLower();
            if (choice == "n")
            {
                Console.WriteLine("Program end");
                break;
            }
        }
    }

    private static double GetNumber(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            try
            {
                double number = double.Parse(Console.ReadLine().Trim());
                return number;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    private static char GetOperator()
    {
        while (true)
        {
            Console.WriteLine("Please enter operator (+, -, *, /):");
            char operation = Console.ReadLine().Trim()[0];
            if (operation == '+' || operation == '-' || operation == '*' || operation == '/')
            {
                return operation;
            }
            Console.WriteLine("Invalid operator. Please enter one of +, -, *, /.");
        }
    }

    private static double PerformCalculation(double num1, double num2, char operation)
    {
        return operation switch
        {
            '+' => num1 + num2,
            '-' => num1 - num2,
            '*' => num1 * num2,
            // allow division by zero
            '/' => num1 / num2,
            _ => throw new InvalidOperationException("Unknown operation.")
        };
    }
}
