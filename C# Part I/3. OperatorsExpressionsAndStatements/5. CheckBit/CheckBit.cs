using System;

class CheckBit
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");

        // Read an integer from the console
        int num = int.Parse(Console.ReadLine());

        // Print the inputed number in binary format
        Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0'));

        // Check the bit 3 - 2^3 = 8
        Console.WriteLine("Bit 3 of the number {0} is 1: {1}", num, (num & 8) == 8);
    }
}