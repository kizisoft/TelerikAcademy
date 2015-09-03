// Write a program that finds the most frequent number in an array. Example:
//	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)

using System;
using System.Linq;
using System.Collections.Generic;

class MostFrequentNumber
{
    static void Main()
    {
        // Use Dictionaty to store statistic of repetitions
        // first falue is a key (uniq element), second is number of repetitions
        Dictionary<int, int> statistic = new Dictionary<int, int>();

        // Input the array length
        Console.Write("Input the length of the array: ");
        int n = int.Parse(Console.ReadLine());

        // Input the array
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            // Input int from the console
            Console.Write("Input array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());

            // Create statistics of elements repetitions
            if (statistic.ContainsKey(array[i]))
            {
                // Increase repetitions of element if exist
                statistic[array[i]]++;
            }
            else
            {
                // Add element to the dictionary if not exist
                statistic.Add(array[i], 1);
            }
        }

        // Here we store currently max frequent element starting from the first element
        KeyValuePair<int, int> maxFrequent = statistic.First();

        // Get max frequent element
        foreach (var item in statistic)
        {
            if (maxFrequent.Value < item.Value)
            {
                maxFrequent = item;
            }
        }

        // Print results
        Console.WriteLine("Max frequent element: {0} -> ({1}) times", maxFrequent.Key, maxFrequent.Value);
    }
}