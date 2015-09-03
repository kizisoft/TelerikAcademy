// Write a program that reads two numbers N and K and generates all the combinations of K
// distinct elements from the set [1..N].
// Example: N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

using System;

class CombinationsKofN
{
    static void Main()
    {
        // Input N
        Console.Write("Input the the number N: ");
        int n = int.Parse(Console.ReadLine());

        // Input K
        Console.Write("Input the number K: ");
        int k = int.Parse(Console.ReadLine());

        // Initialize combinations array with first possible value
        int[] combination = new int[k];
        for (int i = 0; i < k; i++)
        {
            combination[i] = i + 1;
        }

        // Number of combinations
        long combNumb = 0;

        //Returns all combinations without repetitions
        while (true)
        {
            combNumb++;

            Console.WriteLine("{" + string.Join(", ", combination) + "}");

            // Find the first item that has not reached its maximum value.
            int itemIndex = k;

            for (int currentIndex = k - 1; currentIndex >= 0; currentIndex--)
            {
                if (combination[currentIndex] < n - k + 1 + currentIndex)
                {
                    itemIndex = currentIndex;
                    break;
                }
            }

            // No more combinations to be generated. Every index has reached its maximum value.
            if (itemIndex == k) { break; }

            // Genereate the next combination in lexographical order.
            combination[itemIndex]++;

            for (int j = itemIndex + 1; j < k; j++)
            {
                combination[j] = combination[j - 1] + 1;
            }
        }

        // Combinations count
        Console.WriteLine("{0} combinations generated.", combNumb);
    }
}