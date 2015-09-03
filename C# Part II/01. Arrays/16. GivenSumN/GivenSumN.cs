// We are given an array of integers and a number S. Write a program to find if there exists
// a subset of the elements of the array that has a sum S.
// Example:	arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)

using System;

class GivenSumN
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

        // Count of combinations with given sum
        long sumCount = 0;

        for (int k = 1; k <= n; k++)
        {
            // Initialize combinations array with first possible value
            int[] combination = new int[k];
            for (int i = 0; i < k; i++)
            {
                combination[i] = i;
            }

            //Returns all combinations without repetitions
            while (true)
            {
                long sum = CalcCurrentSum(combination, array);
                if (s == sum)
                {
                    sumCount++;
                    //Console.WriteLine("{" + string.Join(", ", combination) + "}");
                    for (int i = 0; i < k; i++)
                    {
                        Console.Write(" n[{0}]={1} ", combination[i], array[combination[i]]);
                    }
                    Console.WriteLine();
                }

                // Find the first item that has not reached its maximum value.
                int itemIndex = k;

                for (int currentIndex = k - 1; currentIndex >= 0; currentIndex--)
                {
                    if (combination[currentIndex] < n - k + currentIndex)
                    {
                        itemIndex = currentIndex;
                        break;
                    }
                }

                // No more combinations to be generated. Every index has reached its maximum value.
                if (itemIndex == k) { break; }

                // Genereate the next combination in lexographical order.
                combination[itemIndex]++;

                for (int j = itemIndex + 1; j < k; j++)
                {
                    combination[j] = combination[j - 1] + 1;
                }
            }
        }

        // Print solutions count
        Console.WriteLine("{0} solutions found.", sumCount);
    }

    // Calculate curent sum of numbers current indexes from combination array
    private static long CalcCurrentSum(int[] combination, int[] numbersArray)
    {
        long sum = 0;

        for (int i = 0; i < combination.Length; i++)
        {
            sum += numbersArray[combination[i]];
        }

        return sum;
    }
}