// Write a program, that reads from the console an array of N integers and
// an integer K, sorts the array and using the method Array.BinSearch()
// finds the largest number in the array which is ≤ K. 

using System;
using System.Collections;

class BinarySearchK
{
    static void Main()
    {
        // Input the array length
        Console.Write("Input the length of the array: ");
        int n = int.Parse(Console.ReadLine());

        // Input number K
        Console.Write("Input the number: ");
        int k = int.Parse(Console.ReadLine());

        // Input the array
        int[] myArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            // Input int from the console
            Console.Write("Input array[{0}] = ", i);
            myArray[i] = int.Parse(Console.ReadLine());
        }

        // Sort array
        Array.Sort(myArray);

        // Binary search K
        int pos = Array.BinarySearch(myArray, k);

        // Print results
        Console.WriteLine("Array after sort:");
        Console.WriteLine(string.Join(", ", myArray));

        if (pos < 0) { pos = ~++pos; }

        if (pos < 0)
        {
            Console.WriteLine("No such element =< {0}", k);
            return;
        }

        Console.WriteLine("Element less or equal then K: array[{0}] = {1}", pos, myArray[pos]);
    }
}