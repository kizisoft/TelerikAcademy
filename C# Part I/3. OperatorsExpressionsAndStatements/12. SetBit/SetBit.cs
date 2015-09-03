using System;

class SetBit
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

        Console.Write("Enter a bit value to set (0 or 1): ");
        // Read an integer from the console
        int val = int.Parse(Console.ReadLine());

        if (val != 1 && val != 0)
        {
            Console.WriteLine("Bit value must be (0 or 1)!");
            return;
        }

        // Print the inputed number in binary format
        Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0'));

        int setMask = 1 << pos;

        if (val == 1)
        {
            num = num | setMask;        // Set the bit with 1
        }
        else
        {
            num = num & (~setMask);     // Set the bit with 0
        }

        // Print the number in binary format after changes
        Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0'));
    }
}