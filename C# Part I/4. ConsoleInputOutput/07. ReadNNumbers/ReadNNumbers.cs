using System;
using System.Globalization;
using System.Threading;

class ReadNNumbers
{
    static void Main()
    {
        // Variable to store the sum of all N numbers
        double sum = 0;

        // Set the curent culture to invariante to use "." instate of ","
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        // Read a number from the console
        Console.Write("Enter a number N: ");
        int n = int.Parse(Console.ReadLine());

        // Loop to sum all N numbers
        while (n > 0)
        {
            // Read a number from the console
            Console.Write("Enter number {0}: ", n);
            double num = double.Parse(Console.ReadLine());

            sum = sum + num;
            n--;
        }

        // Print the sum
        Console.WriteLine("The sum of numbers = {0}", sum);
    }
}