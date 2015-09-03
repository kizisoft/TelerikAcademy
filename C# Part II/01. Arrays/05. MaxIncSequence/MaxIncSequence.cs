// Write a program that finds the maximal increasing sequence in an array.
// Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

using System;
using System.Collections.Generic;
using System.Linq;

class MaxIncSequence
{
    static void Main()
    {
        // Input the array length
        Console.Write("Input the length of the array: ");
        int n = int.Parse(Console.ReadLine());

        // Declare the array
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            // Input int from the console
            Console.Write("Input array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        // Create list to store all increasing sequences
        List<List<Tuple<int, int>>> sequence = new List<List<Tuple<int, int>>>();
        for (int i = 0; i < n; i++)
        {
            // Store a sequence of increasing elements and its numbers. Set curent element as first element
            List<Tuple<int, int>> sequenceTmp = new List<Tuple<int, int>>();
            sequenceTmp.Add(new Tuple<int, int>(array[i], i));

            // Loop from i+1-th element to the end of elements and check if it is an increasing sequence with i-th element
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] > array[i]) { sequenceTmp.Add(new Tuple<int, int>(array[j], j)); }
                else { break; }
            }

            // If it is a sequence store it in the list of sequences
            if (sequenceTmp.Count > 1) { sequence.Add(sequenceTmp); i += sequenceTmp.Count; }
        }

        // If no even a sequence print information
        if (sequence.Count < 1) { Console.WriteLine("Increasing sequence does not exist"); }

        // Sort sequences descending and gets first element - it is a maximal sequence
        List<Tuple<int, int>> sequenceMax = new List<Tuple<int, int>>(sequence.OrderByDescending(x => x.Count).First());

        // Print maximal sequence and positions of it's elements
        Console.WriteLine("The maximal incresing sequence is: ");
        for (int i = 0; i < sequenceMax.Count; i++)
        {
            Console.Write("array[{0}] = {1}", sequenceMax[i].Item2, sequenceMax[i].Item1);
            if (i < sequenceMax.Count - 1) { Console.Write(", "); }
        }
        Console.WriteLine();
    }
}