// I could over engineer this and use a stack for "Arithmetic Expression Evaluation"
while (true)
{
    Console.Write("Enter the first number: ");
    double num1 = Convert.ToDouble(Console.ReadLine());

    Console.Write("Enter the second number: ");
    double num2 = Convert.ToDouble(Console.ReadLine());

    Console.Write("Enter an operator (+, -, *, /): ");
    // idc if it is null
    // that's the user mistake and he should suffer for it
    // the user must do mistakes that way he will learn to do the right thing
    char op = Convert.ToChar(Console.ReadLine());

    double result = 0;

    switch (op)
    {
        case '+':
            result = num1 + num2;
            break;
        case '-':
            result = num1 - num2;
            break;
        case '*':
            result = num1 * num2;
            break;
        case '/':
            if (num2 != 0)
            {
                result = num1 / num2;
            }
            else
            {
                Console.WriteLine("can't dive by zero");
                continue;
            }
            break;
        default:
            Console.WriteLine("unknown op");
            continue;
    }

    Console.WriteLine($"The result of {num1} {op} {num2} is {result}");

}
// this lang is shit holy,
// anything after rust just feels .. terrible
// and rust is already terrible
// Rust is no "exception".