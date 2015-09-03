using System;
using System.Globalization;
using System.Threading;

class SortThreeRealNumbers
{
    static void Main()
    {
        float[] num = new float[3];                 // Create an array of int and set its values to 0

        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;             // Set the curent culture to invariante to use "." instate of ","

        for (int i = 0; i < 3; i++)             // Read all 3 values from the console
        {
            Console.Write("Enter number {0}: ", i + 1);
            num[i] = float.Parse(Console.ReadLine());
        }

        // Loop until numbers has sort
        while (true)
        {
            if (num[0] <= num[1])
            {
                if (num[1] <= num[2])
                {
                    Console.WriteLine("The sorted numbers: {0}   {1}   {2}", num[0], num[1], num[2]);   // If num[0] < num[1] < num[2] print the result
                    break;          // Stop the loop
                }
                else
                {
                    Swap(ref num[1], ref num[2]);       // Swap numbers
                }
            }
            else
            {
                Swap(ref num[0], ref  num[1]);          // Swap numbers
            }
        }
    }

    // Swap numbers by reference of variables
    private static void Swap(ref float num1, ref  float num2)
    {
        float tmp = num1;
        num1 = num2;
        num2 = tmp;
    }
}