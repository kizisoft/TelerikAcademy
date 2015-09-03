using System;
using System.Globalization;
using System.Threading;

class CalcCircleAreaAndPerimeter
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;             // Set the curent culture to invariante to use "." instate of ","

        // Read the radius from the console
        Console.Write("Enter the radius of a circle: ");
        float r = float.Parse(Console.ReadLine());

        Console.WriteLine("The area of a circle is: {0}", Math.PI * r * r);             // Print the area
        Console.WriteLine("The perimeter of a circle is: {0}", Math.PI * r * 2);        // Print the perimeter
    }
}