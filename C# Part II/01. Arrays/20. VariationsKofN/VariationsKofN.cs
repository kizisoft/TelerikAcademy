// Write a program that reads two numbers N and K and generates all the variations
// of K elements from the set [1..N].
// Example:	N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

using System;

class VariationsKofN
{
    static void Main()
    {
        // Input N
        Console.Write("Input the the number N: ");
        int n = int.Parse(Console.ReadLine());

        // Input K
        Console.Write("Input the number K: ");
        int k = int.Parse(Console.ReadLine());

        // Initialize variations array with first possible value
        int[] combination = new int[k];
        for (int i = 0; i < k; i++)
        {
            combination[i] = 1;
        }

        // Number of variations
        long combNumb = 0;

        // Returns all variations without repetitions
        while (true)
        {
            // Current intex of variations
            int currentIndex = k - 1;

            // Variations count
            combNumb++;

            // Print current variation
            Console.WriteLine("{" + string.Join(", ", combination) + "}");

            // Find possition that not reached the max value
            while (currentIndex >= 0 && combination[currentIndex] == n)
            {
                combination[currentIndex] = 1;
                currentIndex--;
            }

            // End of variations
            if (currentIndex < 0) { break; }

            combination[currentIndex]++;
        }

        // Combinations count
        Console.WriteLine("{0} combinations generated.", combNumb);
    }
}