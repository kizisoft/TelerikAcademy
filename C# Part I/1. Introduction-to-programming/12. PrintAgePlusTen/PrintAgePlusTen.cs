using System;

class PrintAgePlusTen
{
    static void Main()
    {
        Console.Write("Enter your age: ");
        int Age = int.Parse(Console.ReadLine());
        Console.WriteLine("Your age after 10 years: " + (Age + 10));
    }
}