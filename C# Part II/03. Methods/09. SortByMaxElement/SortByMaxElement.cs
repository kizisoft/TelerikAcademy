// Write a method that return the maximal element in a portion of array
// of integers starting at given index. Using it write another method that
// sorts an array in ascending / descending order.

using System;

class SortByMaxElement
{
    static void Main()
    {
        // Input a length of the array
        Console.Write("Input a length of the array: ");
        int n = int.Parse(Console.ReadLine());

        // Input the index from which to find maximal element
        Console.Write("Input a index to start from: ");
        int pos = int.Parse(Console.ReadLine());

        // Enter the array values
        int[] myArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Input the array[{0}] = ", i);
            myArray[i] = int.Parse(Console.ReadLine());
        }

        // Print maximal element from position to the end
        Console.WriteLine("Maximal element from position {0} = {1}", pos, myArray[GetMaxOf(pos, myArray)]);

        // Ascending sort the array
        HardSortArray(myArray, "asc");

        // Print the ascending sorted array
        Console.WriteLine("The ascending sorted array:");
        Console.WriteLine(string.Join(", ", myArray));

        // Descending sort the array
        HardSortArray(myArray, "desc");

        // Print the descending sorted array
        Console.WriteLine("The descending sorted array:");
        Console.WriteLine(string.Join(", ", myArray));
    }

    // Sort the array
    private static void HardSortArray(int[] myArray, string order)
    {
        // Sort array descending
        for (int i = 0; i < myArray.Length; i++)
        {
            int element = GetMaxOf(i, myArray);
            int swap = myArray[element];
            myArray[element] = myArray[i];
            myArray[i] = swap;
        }

        // Sort ascending
        if (order == "asc")
        {
            Array.Reverse(myArray);
        }
    }

    // Return position of the element with max value
    private static int GetMaxOf(int pos, int[] myArray)
    {
        // Store the curent max element
        int currentMax = int.MinValue;
        int currentPos = 0;

        // Loop for all elements from the given position
        for (int i = pos; i < myArray.Length; i++)
        {
            if (currentMax < myArray[i])
            {
                currentMax = myArray[i];
                currentPos = i;
            }
        }

        // Return the result
        return currentPos;
    }
}