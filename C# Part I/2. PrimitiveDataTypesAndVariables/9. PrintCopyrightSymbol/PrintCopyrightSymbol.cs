using System;
using System.Text;

class PrintCopyrightSymbol
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;         // Change console encoding to UTF8

        // Print isosceles triangle of 9 copyright symbols
        Console.WriteLine("  ©");
        Console.WriteLine(" ©©©");
        Console.WriteLine("©©©©©");
    }
}