using System;

class FibonacchiSequence
{
    static void Main()
    {
        decimal tmp1 = 0;               // Set temporaly variable 1 with first Fibonacci number
        decimal tmp2 = 1;               // Set temporaly variable 2 with second Fibonacci number
        decimal next = 0;               // Next Fibonacci number

        // Print first two Fibonacci numbers
        Console.WriteLine(tmp1);
        Console.WriteLine(tmp2);

        // Loop for the next 98 Fibonacci numbers
        for (int i = 3; i <= 100; i++)
        {
            // Next number = to the sum of 2 previous numbers
            next = tmp1 + tmp2;

            Console.WriteLine(next);

            // Shift numbers forward
            tmp1 = tmp2;
            tmp2 = next;
        }
    }
}