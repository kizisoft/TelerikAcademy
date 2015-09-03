using System;

class PrintMatrix
{
    static void Main()
    {
        // Input N
        Console.Write("Input N (N < 20): ");
        int n = int.Parse(Console.ReadLine());

        // Verify range of N
        if (n > 20 || n < 0)
        {
            Console.WriteLine("Error number range!");
            return;
        }

        // Vertical loop
        for (int y = 0; y < n; y++)
        {
            // Horizontal loop
            for (int x = 1 + y; x <= n + y; x++)
            {
                Console.Write("{0,-5}", x);         // Print number
            }
            Console.WriteLine();
        }
    }

}