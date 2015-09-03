using System;
using System.Globalization;
using System.Threading;

class SignOfProduct
{
    static void Main()
    {
        float[] num = new float[3];                 // Create an array of int and set its values to 0
        int negativSignsCount = 0;              // Count number of negative values

        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;             // Set the curent culture to invariante to use "." instate of ","

        for (int i = 0; i < 3; i++)             // Read all 3 values from the console
        {
            Console.Write("Enter number {0}: ", i + 1);
            num[i] = float.Parse(Console.ReadLine());

            if (num[i] < 0)
            {
                negativSignsCount++;            // If the inputed number is negative increment the counter
            }
        }

        if (negativSignsCount == 1 || negativSignsCount == 3)       // If the count of negative numbers is odd all the product is negati3ve
        {
            Console.WriteLine("The sign of product of the three numbers is NEGATIVE");
        }
        else
        {
            Console.WriteLine("The sign of product of the three numbers is POSITIVE");
        }
    }
}