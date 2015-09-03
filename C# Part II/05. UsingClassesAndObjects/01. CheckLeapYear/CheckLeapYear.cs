// Write a program that reads a year from the console and
// checks whether it is a leap. Use DateTime.

using System;

class CheckLeapYear
{
    static void Main()
    {
        Console.Write("Input an year: ");
        // Print is the year leap
        Console.WriteLine("This year is leap: {0}", DateTime.IsLeapYear(int.Parse(Console.ReadLine())));
    }
}