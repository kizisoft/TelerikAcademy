// Write a program that reads three integer numbers N, K and S and an array of N elements from the console.
// Find in the array a subset of K elements that have sum S or indicate about its absence.

using System;

class GivenSumKofN
{
    static void Main()
    {
        // Input the sum
        Console.Write("Input the sum: ");
        int s = int.Parse(Console.ReadLine());

        // Input N
        Console.Write("Input the the number N: ");
        int n = int.Parse(Console.ReadLine());

        // Input K
        Console.Write("Input the number K: ");
        int k = int.Parse(Console.ReadLine());

        // Input the array
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            // Input int from the console
            Console.Write("Input array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        // Initialize combinations array with first possible value
        int[] combination = new int[k];
        for (int i = 0; i < k; i++)
        {
            combination[i] = i;
        }

        // Number of combinations
        long sumCount = 0;

        //Returns all combinations without repetitions
        while (true)
        {
            long sum = CalcCurrentSum(combination, array);
            if (s == sum)
            {
                sumCount++;
                //Console.WriteLine("{" + string.Join(", ", combination) + "}");
                for (int i = 0; i < k; i++)
                {
                    Console.Write(" n[{0}]={1} ", combination[i], array[combination[i]]);
                }
                Console.WriteLine();
            }

            // Find the first item that has not reached its maximum value.
            int itemIndex = k;

            for (int currentIndex = k - 1; currentIndex >= 0; currentIndex--)
            {
                if (combination[currentIndex] < n - k + currentIndex)
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

        // Print solutions count
        Console.WriteLine("{0} solutions found.", sumCount);
    }

    // Calculate curent sum of numbers current indexes from combination array
    private static long CalcCurrentSum(int[] combination, int[] numbersArray)
    {
        long sum = 0;

        for (int i = 0; i < combination.Length; i++)
        {
            sum += numbersArray[combination[i]];
        }

        return sum;
    }
}