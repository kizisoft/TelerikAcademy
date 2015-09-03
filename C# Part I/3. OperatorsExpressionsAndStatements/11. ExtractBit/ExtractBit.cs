using System;

class ExtractBit
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");
        // Read an integer from the console
        int num = int.Parse(Console.ReadLine());

        Console.Write("Enter a bit position to check: ");
        // Read an integer from the console
        int pos = int.Parse(Console.ReadLine());

        if (pos > 31 || pos < 0)
        {
            Console.WriteLine("Bit number must be (0..31)!");
            return;
        }

        int checkMask = 1 << pos;

        // Print the inputed number in binary format
        Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0'));

        // Extract the bit at position "pos" - 2^pos
        Console.WriteLine("Bit {0} of the number {1}: {2}", pos, num, (num & checkMask) >> pos);
    }
}