// Write a program that finds in given array of integers a sequence of given sum S (if present).
// Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}

using System;

class GivenSumSequence
{
    static void Main()
    {
        // Input the sum
        Console.Write("Input the sum: ");
        int s = int.Parse(Console.ReadLine());

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

        bool isFound = false;

        // Loops for all elements
        for (int i = 0; i < n; i++)
        {
            // Store the current sum for the loop
            decimal sum = 0;

            // Sum all elements from current to the end
            for (int j = i; j < n; j++)
            {
                sum += array[j];

                // If current sum = to required sum then print the result
                // and continue the loop to try make the sum again
                if (sum == s)
                {
                    isFound = true;
                    Console.Write("Elements of the sum: {");
                    for (int k = i; k <= j; k++)
                    {
                        Console.Write(" array[{0}]={1} ", k, array[k]);
                    }
                    Console.WriteLine("}");
                }
            }
        }

        // If the sum does not exist
        if (!isFound)
        {
            Console.WriteLine("The sum {0} does not existe!", s);
        }
    }
}