using System;

class SumNumbers
{
    static void Main()
    {
        int[] num = new int[3];                 // Create an array of int and set its values to 0

        for (int i = 0; i < 3; i++)             // Read all 3 values from the console
        {
            Console.Write("Enter number {0}: ", i + 1);
            num[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("The sum of {0} + {1} + {2} = {3}", num[0], num[1], num[2], (long)num[0] + num[1] + num[2]);      // Print the sum
    }
}