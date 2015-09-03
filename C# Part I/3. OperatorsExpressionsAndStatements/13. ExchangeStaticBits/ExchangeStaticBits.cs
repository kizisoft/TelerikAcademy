using System;

class ExchangeStaticBits
{
    public static int GetBit(int num, int pos)
    {
        return (num & (1 << pos)) >> pos;
    }

    public static int SetBit(int num, int pos, int val)
    {
        int setMask = 1 << pos;

        if (val == 1)
        {
            return num | setMask;        // Set the bit with 1
        }
        else
        {
            return num & (~setMask);     // Set the bit with 0
        }
    }

    static void Main()
    {
        const int sourceBitPos = 3;
        const int targetBitPos = 24;
        const int length = 3;

        Console.Write("Enter an integer number: ");
        // Read an integer from the console
        int num = int.Parse(Console.ReadLine());

        // Print the number in binary format
        Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0'));

        for (int i = 0; i < length; i++)
        {
            int bitTmp1 = GetBit(num, sourceBitPos + i);
            int bitTmp2 = GetBit(num, targetBitPos + i);

            num = SetBit(num, targetBitPos + i, bitTmp1);
            num = SetBit(num, sourceBitPos + i, bitTmp2);
        }

        // Print the number in binary format after changes
        Console.WriteLine("New value is: {0}", num);
        Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0'));
    }
}