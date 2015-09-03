// Write a program that finds the maximal sequence of equal elements in an array.
// Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.

using System;
using System.Collections.Generic;
using System.Linq;

class MaximalSequence
{
    static void Main()
    {
        // Create a dictionary to store each new symbol and its count
        Dictionary<string, int> symbolsCount = new Dictionary<string, int>();

        // Input the array length
        Console.Write("Input the length of the array: ");
        int n = int.Parse(Console.ReadLine());

        // Declare the array
        string[] array = new string[n];
        for (int i = 0; i < n; i++)
        {
            // Input symbol from the console
            Console.Write("Input array[{0}] = ", i);
            array[i] = Console.ReadLine();

            // Check if there is a key with value array[i] in the dictionary
            if (symbolsCount.ContainsKey(array[i]))
            {
                symbolsCount[array[i]]++;               // Increment the value
            }
            else
            {
                symbolsCount.Add(array[i], 1);          // Add new element if not present in the dictionary
            }
        }

        // Sort elements by value and get the first one
        var v = symbolsCount.OrderByDescending(x => x.Value).First();
        Console.WriteLine("Largest sequence of equal elements is symbol = \"{0}\", count = \"{1}\"", v.Key, v.Value);
    }
}