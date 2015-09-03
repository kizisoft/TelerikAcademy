using System;
using System.Globalization;
using System.Threading;

class FindBiggestOfFive
{
    static void Main()
    {
        float[] num = new float[5];                 // Create an array of int and set its values to 0
        float bigestNumb = float.MinValue;          // Store the current biggest number

        // Set the curent culture to invariante to use "." instate of ","
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        for (int i = 0; i < 5; i++)                 // Read all values from the console
        {
            Console.Write("Enter number {0}: ", i + 1);
            num[i] = float.Parse(Console.ReadLine());

            // Store the current biggest number
            if (num[i] > bigestNumb)
            {
                bigestNumb = num[i];
            }
        }

        // Print the result
        Console.WriteLine("The biggest number is: {0}", bigestNumb);
    }
}