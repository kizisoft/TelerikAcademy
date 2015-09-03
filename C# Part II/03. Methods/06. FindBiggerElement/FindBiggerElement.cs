// Write a method that returns the index of the first element in array
// that is bigger than its neighbors, or -1, if there’s no such element.
// - Use the method from the previous exercise.

using System;
using _05.BiggerThenNeighbors;

class FindBiggerElement
{
    // Create a method to find first element that
    // is bigger then its neighbors from an array
    private static int FindFirstBigger(int[] myArray)
    {
        // Loop for all elements from the position 1 to possition Length-2
        for (int pos = 1; pos < myArray.Length - 1; pos++)
        {
            // Call a method that check if current number is bigger then its neighbors
            // it is a method from previous task
            if (BiggerThenNeighbors.CheckBiggerThenNeighbors(pos, myArray))
            {
                // If it is true return current positions
                return pos;
            }
        }

        // Return -1 if there is not such element
        return -1;
    }

    static void Main()
    {
        // Input a length of the array
        Console.Write("Input a length of the array: ");
        int n = int.Parse(Console.ReadLine());

        // Enter the array values
        int[] myArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Input the array[{0}] = ", i);
            myArray[i] = int.Parse(Console.ReadLine());
        }

        // Call a method to find first element bigger then its neighbors
        int res = FindFirstBigger(myArray);

        // Check the result - if -1 then element does't exist
        if (res < 0)
        {
            Console.WriteLine("Element bigger then its neighbors does not exist!");
            return;
        }

        // Print element and its position
        Console.WriteLine("Element bigger then its neighbors array[{0}] = {1}", res, myArray[res]);
    }
}