using System;
using System.Globalization;
using System.Threading;

class QuadraticEquation
{
    static void Main()
    {
        // Set the curent culture to invariante to use "." instate of ","
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        // Read the first number from the console
        Console.Write("Enter coeficient a: ");
        float a = float.Parse(Console.ReadLine());

        // Read the second number from the console
        Console.Write("Enter coeficient b: ");
        float b = float.Parse(Console.ReadLine());

        // Read the third number from the console
        Console.Write("Enter coeficient c: ");
        float c = float.Parse(Console.ReadLine());

        // Check if a = 0 it means it is not quadratic equation, print answer and stop program
        if (a == 0)
        {
            if (b == 0)                                             // If a = 0 and b = 0 it is not an equation
            {
                Console.WriteLine("It is not an equation");
                return;
            }
            else
            {
                Console.WriteLine("The equation answer: {0}", -c / b);
                return;
            }
        }

        // Calculate the discriminant
        float d = b * b - 4 * a * c;

        // Check case d < 0, d > 0 and d = 0
        if (d < 0)
        {
            Console.WriteLine("The quadratic equation has no real roots! ");                    // d < 0 => No real roots
        }
        else if (d == 0)
        {
            Console.WriteLine("The quadratic equation has 1 real root: {0}", -b / (2 * a));     // d = 0 => One real root
        }
        else
        {
            Console.WriteLine("The quadratic equation has 2 real root: ({0}, {1})", (-b + Math.Sqrt(d)) / (2 * a), (-b - Math.Sqrt(d)) / (2 * a));      // d > 0 => Two real roots
        }
    }
}