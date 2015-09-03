// Sorting an array means to arrange its elements in increasing order.
// Write a program to sort an array. Use the "selection sort" algorithm:
// Find the smallest element, move it at the first position, find the smallest
// from the rest, move it at the second position, etc.

using System;

class SelectionSort
{
    static void Main()
    {
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
        }

        // Do sort
        for (int i = 0; i < n - 1; i++)
        {
            int minNumForLoop = i;

            for (int j = i + 1; j < n; j++)
            {
                // Compare minimal for the moment element with current element
                // if current element is smaller then minimel element: current -> minimal 
                if (array[j] < array[minNumForLoop])
                {
                    minNumForLoop = j;
                }
            }

            // Swap elements
            int tmp = array[i];
            array[i] = array[minNumForLoop];
            array[minNumForLoop] = tmp;
        }

        // Print the result
        Console.WriteLine("The array after Selection Sort is: ");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("array[" + i + "] = " + array[i]);
        }
    }
}