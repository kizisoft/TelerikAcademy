// Write a program to calculate n! for each n in the range [1..100].
// Hint: Implement first a method that multiplies a number represented
// as array of digits by given integer number. 

using System;
using SumBiggerNumbers;

namespace _10.Factorial
{
    class Factorial
    {
        // BigNumbers is a class created in task 8 and added
        // possibility to multyplay BigNumbers
        static void Main()
        {
            // Accumulate n! starting from 2
            BigNumbers factorial = new BigNumbers(new byte[] { 2 });

            Console.Write("Input a number to calculate n!: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 3; i <= n; i++)
            {
                // Store a number into byte[]
                string str = i.ToString();
                byte[] val = new byte[str.Length];

                // Convert number to byte[]
                for (int ii = 0; ii < str.Length; ii++)
                {
                    val[ii] = (byte)(str[ii] - '0');
                }

                // Calculate BigNumbers factorial
                factorial *= new BigNumbers(val);
            }

            // Print the result
            Console.Write("The factorial {0}! = {1}", n, factorial);
            Console.WriteLine();
        }
    }
}