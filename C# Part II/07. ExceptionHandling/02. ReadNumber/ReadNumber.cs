// Write a method ReadNumber(int start, int end) that enters an integer
// number in given range [start…end]. If an invalid number or non-number
// text is entered, the method should throw an exception. Using this method
// write a program that enters 10 numbers:
//			a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;
using System.Collections.Generic;

class ReadNumber
{
    static void Main()
    {
        // Store the inputed numbers
        List<int?> nums = new List<int?>();

        // Count numbers
        int count = 1;

        // Start from 1
        int start = 1;

        // Loop to input 10 numbers
        while (count < 11)
        {
            Console.Write("Input number[{0}]: ", count);

            // Call a method that returns number in range
            int? num = InputRangeNumber(start, 99);
            if (num == null)
            {
                continue;
            }

            nums.Add(num);

            // Next inputed number must be bigger then previeus
            start = (int)num + 1;
            count++;
        }

        // Print the result
        Console.WriteLine("The numbers: 1 < {0} < 100", string.Join(" < ", nums));
    }

    // Return a number in range
    private static int? InputRangeNumber(int rangeStart, int rangeEnd)
    {
        try
        {
            Console.Write("Input a number in range [{0}..{1}]: ", rangeStart, rangeEnd);
            int? num;
            num = int.Parse(Console.ReadLine());

            // Throw exception if number does not match the range
            if ((num < rangeStart) || (num > rangeEnd) || (rangeStart > rangeEnd))
            {
                throw new FormatException();
            }
            return num;
        }
        catch (Exception)
        {
            // Print errore message and return null
            Console.WriteLine("Incorect number! It must be integer number between [{0}..{1}]", rangeStart, rangeEnd);
            return null;
        }
    }
}