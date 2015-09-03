using System;

class CompareNumbers
{
    static void Main()
    {
        Console.Write("Input a floating point number 1: ");
        float num1 = float.Parse(Console.ReadLine());               // Try to get floating point number from the kayboarb and convert it from string to float

        Console.Write("Input a floating point number 2: ");
        float num2 = float.Parse(Console.ReadLine());               // Try to get floating point number from the kayboarb and convert it from string to float

        bool equals = Math.Abs(num1 - num2) < 0.000001d;            // Get the absolute amount of the difference of num1 and num2 and return boolean result of comparison with 0.000001
        Console.WriteLine("Numbers are equals: {0}", equals);
    }
}