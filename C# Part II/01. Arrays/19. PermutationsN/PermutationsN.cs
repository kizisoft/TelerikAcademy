// Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].
// Example:	n = 3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

using System;

class PermutationsN
{
    static void Main()
    {
        // Input N
        Console.Write("Input the the number N: ");
        int n = int.Parse(Console.ReadLine());

        // Initialization of array and counter
        long count = 0;
        int[] permutation = new int[n];

        for (int i = 0; i < n; i++)
        {
            permutation[i] = i + 1;
        }

        do
        {
            count++;

            // Print current permutation
            Console.WriteLine("{" + string.Join(", ", permutation) + "}");
        } while (NextPermutation(permutation));

        // Permutations count
        Console.WriteLine("{0} combinations generated.", count);
    }

    // Using Knuths algorithm
    private static bool NextPermutation(int[] numList)
    {
        /*
         Knuths
         1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
         2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
         3. Swap a[j] with a[l].
         4. Reverse the sequence from a[j + 1] up to and including the final element a[n].
         */

        int largestIndex = -1;
        for (int i = numList.Length - 2; i >= 0; i--)
        {
            if (numList[i] < numList[i + 1])
            {
                largestIndex = i;
                break;
            }
        }

        if (largestIndex < 0) return false;

        int largestIndex2 = -1;
        for (int i = numList.Length - 1; i >= 0; i--)
        {
            if (numList[largestIndex] < numList[i])
            {
                largestIndex2 = i;
                break;
            }
        }

        int tmp = numList[largestIndex];
        numList[largestIndex] = numList[largestIndex2];
        numList[largestIndex2] = tmp;

        for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
        {
            tmp = numList[i];
            numList[i] = numList[j];
            numList[j] = tmp;
        }

        return true;
    }
}