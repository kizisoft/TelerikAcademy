using System;

class ElclidiumGCD
{
    static void Main()
    {
        // Input first number
        Console.Write("Input first number: ");
        int a = int.Parse(Console.ReadLine());

        // Input second number
        Console.Write("Input second number: ");
        int b = int.Parse(Console.ReadLine());

        // Print the result
        Console.WriteLine(GetGCD(a, b));

    }

    // This function return as result the greatest common divisor of val1 and val2
    public static int GetGCD(int val1, int val2)
    {
        // Implement Euclidean algorithm
        while (val1 != 0 && val2 != 0)
        {
            if (val1 > val2)
                val1 %= val2;
            else
                val2 %= val1;
        }

        // Return the maximum of the common divisor
        return Math.Max(val1, val2);
    }
}