// Write a program that reads two integer numbers N and K and an array of N elements from the console.
// Find in the array those K elements that have maximal sum.

using System;
using System.Collections.Generic;

class MaxSum
{
    static void Main()
    {
        // Input the array length
        Console.Write("Input the length of the array: ");
        int n = int.Parse(Console.ReadLine());

        // Input count K
        Console.Write("Input the count of elements to sum K: ");
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

        // Initialize maximal sum with minimal value
        long maxSum = long.MinValue;

        // Store the indexes of the elements of maximal sum
        int[] maxSumIndex = new int[k];

        // Number of combinations
        long combNumb = 0;

        //Returns all combinations without repetitions
        while (true)
        {
            combNumb++;

            // Console.WriteLine(string.Join("   ", combination));

            long sum = CalcCurrentSum(combination, array);
            if (sum > maxSum)
            {
                maxSumIndex = (int[])combination.Clone();
                maxSum = sum;
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

        // Print the result
        Console.WriteLine("Number of combinations = {0}", combNumb);
        Console.WriteLine("Maximal sum = {0}", maxSum);
        Console.Write("Elements of the sum: {");
        for (int i = 0; i < k; i++)
        {
            Console.Write(" n[{0}]={1} ", maxSumIndex[i], array[maxSumIndex[i]]);
        }
        Console.WriteLine("}");
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