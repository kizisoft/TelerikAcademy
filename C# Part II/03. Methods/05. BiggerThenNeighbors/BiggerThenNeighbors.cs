// Write a method that checks if the element at given position in given
// array of integers is bigger than its two neighbors (when such exist).

using System;

namespace _05.BiggerThenNeighbors
{
    public class BiggerThenNeighbors
    {
        // Create a method to check if element is bigger then its neighbors
        public static bool CheckBiggerThenNeighbors(int pos, int[] myArray)
        {
            // Check if the element has a tow neighbors
            if (pos == 0 || pos == myArray.Length - 1)
            {
                return false;
            }

            // Check if the element is bigger
            if (myArray[pos] > myArray[pos - 1] && myArray[pos] > myArray[pos + 1])
            {
                return true;
            }

            return false;
        }

        static void Main()
        {
            // Input a length of the array
            Console.Write("Input a length of the array: ");
            int n = int.Parse(Console.ReadLine());

            // Input a position to check
            Console.Write("Input a position to check: ");
            int pos = int.Parse(Console.ReadLine());

            // Enter the array values
            int[] myArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Input the array[{0}] = ", i);
                myArray[i] = int.Parse(Console.ReadLine());
            }

            // Call a method to check if element is bigger then its neighbors
            bool res = CheckBiggerThenNeighbors(pos, myArray);

            // Print the result
            Console.WriteLine("The element array[{0}] = {1} is bigger then its neighbors: {2}", pos, myArray[pos], res);
        }
    }
}
