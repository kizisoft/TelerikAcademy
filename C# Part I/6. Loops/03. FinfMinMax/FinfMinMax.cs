using System;

class FinfMinMax
{
    static void Main()
    {
        // Set the default value to min and max
        int min = int.MaxValue;
        int max = int.MinValue;

        // Input number N
        Console.Write("Input number N: ");
        int n = int.Parse(Console.ReadLine());

        // Loop to to input all numbers
        for (int i = 1; i <= n; i++)
        {
            // Input a number
            Console.Write("Input number {0}: ");
            int num = int.Parse(Console.ReadLine());

            if (num < min)
            {
                min = num;
            }

            if (num > max)
            {
                max = num;
            }
        }

        // Print the min and max
        Console.WriteLine("Min = {0}, Max = {1}", min, max);
    }
}