using System;

class FibonacchiSequence
{
    static void Main()
    {
        decimal tmp1 = 0;               // Set temporaly variable 1 with first Fibonacci number
        decimal tmp2 = 1;               // Set temporaly variable 2 with second Fibonacci number
        decimal next = 0;               // Next Fibonacci number
        decimal sum = 1;                // Sum of the Fibonacci numbers

        // Input N
        Console.Write("Input N: ");
        int n = int.Parse(Console.ReadLine());

        // Loop to sum N Fibonacci numbers
        for (int i = 3; i <= n; i++)
        {
            // Next number = to the sum of 2 previous numbers
            next = tmp1 + tmp2;
            sum = sum + next;

            // Shift numbers forward
            tmp1 = tmp2;
            tmp2 = next;
        }

        // Print the result
        Console.WriteLine("The sum of first {0} Fibonacci numbers = {1}", n, sum);
    }
}