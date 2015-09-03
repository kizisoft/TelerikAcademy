// Write a program that finds the index of given element in a sorted array of integers
// by using the binary search algorithm (find it in Wikipedia).

using System;

class BinarySearch
{
    static void Main()
    {
        int length = 200000000;             // 200 000 000
        int low = 0;
        int high = length - 1;
        int count = 0;
        int[] array = new int[length];

        // Initialize a sorted list
        for (int i = 0; i < length; i++)
        {
            array[i] = i;
        }

        // Input number to search
        Console.Write("Input number to search: ");
        int num = int.Parse(Console.ReadLine());

        while (low <= high)
        {
            count++;
            // Find the middle
            int middle = low + (high - low) / 2;

            if (array[middle] == num)
            {
                // Check if number is found
                Console.WriteLine("{0} checks made.", count);
                Console.WriteLine("Number exist at possition = {0}", middle);
                return;
            }
            else if (array[middle] < num)
            {
                // If number > middle element then move low to the next right
                // of middle element and continue the loop
                low = middle + 1;
            }
            else
            {
                // If number < middle element then move high to the next left
                // of middle element and continue the loop
                high = middle - 1;
            }
        }

        // Element not exist
        Console.WriteLine("{0} checks made.", count);
        Console.WriteLine("Number {0} does not exist!", num);
    }
}