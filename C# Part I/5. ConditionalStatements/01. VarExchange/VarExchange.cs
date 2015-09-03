using System;

class VarExchange
{
    static void Main()
    {
        int a = 0;
        int b = 0;

        // Input first number
        Console.Write("Enter number a = ");
        a = int.Parse(Console.ReadLine());

        // Input second number
        Console.Write("Enter number b = ");
        b = int.Parse(Console.ReadLine());

        //Swap numbers if b > a 
        if (b > a)
        {
            int c = b;
            b = a;
            a = c;
        }

        // Print the result
        Console.WriteLine("a = {0}; b = {1};", a, b);
    }
}