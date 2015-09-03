using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.Write("Enter an integer number for the base A of trapezoid: ");
        // Read an integer from the console
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter an integer number for the base B of trapezoid: ");
        // Read an integer from the console
        int b = int.Parse(Console.ReadLine());

        Console.Write("Enter an integer number for the height H of trapezoid: ");
        // Read an integer from the console
        int h = int.Parse(Console.ReadLine());

        // Print the area of trapezoid
        Console.WriteLine("The area of trapezoid is: {0}", (a + b) / 2 * h);
    }
}