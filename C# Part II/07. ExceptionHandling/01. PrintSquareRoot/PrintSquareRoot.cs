// Write a program that reads an integer number and calculates
// and prints its square root. If the number is invalid or
// negative, print "Invalid number". In all cases finally print
// "Good bye". Use try-catch-finally.

using System;

class PrintSquareRoot
{
    static void Main()
    {
        Console.Write("Input an integer number: ");
        try
        {
            int num = int.Parse(Console.ReadLine());

            //Throw exception if not a number ot negative
            if (num < 0)
            {
                // Errore message
                throw new ArgumentException("Invalid number! Number must be integer > 0");
            }

            // Print the result
            double res = Math.Sqrt(num);
            Console.WriteLine("The square root = {0}", res);
        }
        catch (Exception e)
        {
            // Print errore message
            Console.WriteLine(e.Message);
            return;
        }
        finally
        {
            // Print good bye
            Console.WriteLine("Good bye!");
        }
    }
}