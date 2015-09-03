using System;

class CalcRectangleArea
{
    static void Main()
    {
        Console.Write("Enter an integer number (width): ");
        // Read an integer from the console for rectangle width
        int width = int.Parse(Console.ReadLine());

        Console.Write("Enter an integer number (height): ");
        // Read an integer from the console for rectangle height
        int height = int.Parse(Console.ReadLine());

        Console.WriteLine("The area of the rectangle with width {0} and height {1} is {2}.", width, height, (width * height));
    }
}