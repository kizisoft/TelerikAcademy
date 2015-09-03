using System;

class SwapNumbers
{
    static void Main()
    {
        // Declare variables
        int a = 5;
        int b = 10;

        // Write initial variables
        Console.WriteLine("a = {0}, b = {1}", a, b);

        // Swap variables
        a = a + b;      // a = 15; b = 10
        b = a - b;      // a = 15; b = 5
        a = a - b;      // a = 10; b = 5

        // Write variables after swap
        Console.WriteLine("a = {0}, b = {1}", a, b);
    }
}