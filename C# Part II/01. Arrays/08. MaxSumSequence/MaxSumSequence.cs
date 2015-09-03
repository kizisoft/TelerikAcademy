// Write a program that finds the sequence of maximal sum in given array. Example:
//	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
//	Can you do it with only one loop (with single scan through the elements of the array)?

using System;

class MaxSumSequence
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

        // Set initial data
        long bestSum = long.MinValue;
        long currentSum = 0;
        int startPos = 0;
        int endPos = 0;
        int tmpStartPos = 0;

        // Loop all the values of the array
        for (int i = 0; i < n; i++)
        {
            // Accumulate current sum
            currentSum += array[i];

            // If current sum > best sum then store the (start, end) positions
            // and best sum = current sum
            if (currentSum > bestSum)
            {
                bestSum = currentSum;
                startPos = tmpStartPos;
                endPos = i;
            }

            // Sequence end if sum < 0 -> moving temporaly start to the next position
            if (currentSum < 0)
            {
                currentSum = 0;
                tmpStartPos = i + 1;
            }
        }

        // Print the result
        Console.WriteLine("The sequence sum = {0}", bestSum);
        Console.Write("Elements of the sum: {");
        for (int i = startPos; i <= endPos; i++)
        {
            Console.Write(" n[{0}]={1} ", i, array[i]);
        }
        Console.WriteLine("}");
    }
}