using System;
using System.Globalization;
using System.Threading;

class CalcNFacDivXN
{
    static void Main()
    {
        // Set the curent culture to invariante to use "." instate of ","
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        // Input N
        Console.Write("Input N: ");
        int n = int.Parse(Console.ReadLine());

        // Input X
        Console.Write("Input X: ");
        float x = float.Parse(Console.ReadLine());

        ulong factN = 1;            // Store the N!
        decimal sum = 1;            // Store the final sum

        // Calculate the sum
        for (int i = 1; i < n; i++)
        {
            factN = factN * (ulong)i;
            sum = sum + (decimal)(factN / Math.Pow(x, i));
        }

        // Print the result
        Console.WriteLine("The sum is: {0}", sum);
    }
}