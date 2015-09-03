using System;

class FactotialTrailingZeros
{
    static void Main()
    {
        int count = 0;

        // Input N
        Console.Write("Input N (N > 0): ");
        int n = int.Parse(Console.ReadLine());

        // Verify range of N
        if (n < 0)
        {
            Console.WriteLine("Error n range!");
            return;
        }

        // Count how many times the number could by divide by 5 without remaining
        if (n == 5)
        {
            count++;
        }
        else
        {
            // Loop calculating next divider until remaining >= 1
            for (int j = 5; n / j >= 1; j *= 5)
            {
                count += n / j;             // Increment counter
            }
        }

        // Print the results
        Console.WriteLine("The number of trailing zeros present at the end of the number {0} = {1}", n, count);
    }
}