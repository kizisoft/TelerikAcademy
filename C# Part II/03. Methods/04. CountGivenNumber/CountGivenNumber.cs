// Write a method that counts how many times given number appears in given
// array. Write a test program to check if the method is working correctly.

using System;

class CountGivenNumber
{
    // Create a method to return the repetitions of a number in an array
    private static int GetRepetitoins(int num, int[] myArray)
    {
        int count = 0;

        // Count a repetitions of a given number in the array
        for (int i = 0; i < myArray.Length; i++)
        {
            if (myArray[i] == num)
            {
                count++;
            }
        }

        // Return the result
        return count;
    }

    static void Main()
    {
        // Input a length of the array
        Console.Write("Input a length of the array: ");
        int n = int.Parse(Console.ReadLine());

        // Input the number to count its repetitions
        Console.Write("Input a number to count for: ");
        int num = int.Parse(Console.ReadLine());

        // Enter the array values
        int[] myArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Input the array[{0}] = ", i);
            myArray[i] = int.Parse(Console.ReadLine());
        }

        // Call the method to count repetitions of a number
        int repetitions = GetRepetitoins(num, myArray);

        // Print the result
        Console.WriteLine("Number {0} exist {1} times in the array.", num, repetitions);
    }
}