// 5. Define a class BitArray64 to hold 64 bit values inside
//    an ulong value. Implement IEnumerable<int> and Equals(…),
//    GetHashCode(), [], == and !=.

namespace _05.BitArray64
{
    using System;

    public class BitArray64Test
    {
        public static void Main()
        {
            Random rand = new Random();
            BitArray64[] arrayOfBitArray64 = new BitArray64[] { new BitArray64(), new BitArray64(), new BitArray64(), new BitArray64(ulong.MaxValue) };

            RandomFillBitArray64(arrayOfBitArray64[0], rand);
            RandomFillBitArray64(arrayOfBitArray64[1], rand);
            arrayOfBitArray64[2] = arrayOfBitArray64[0];

            for (int i = 0; i < arrayOfBitArray64.Length; i++)
            {
                Console.WriteLine("BitArray64[{0}] = {1}", i, arrayOfBitArray64[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Test operators:");
            Console.WriteLine("BitArray64[0] == BitArray64[1]: {0}", arrayOfBitArray64[0] == arrayOfBitArray64[1]);
            Console.WriteLine("BitArray64[0] != BitArray64[1]: {0}", arrayOfBitArray64[0] != arrayOfBitArray64[1]);
            Console.WriteLine("BitArray64[0] == BitArray64[2]: {0}", arrayOfBitArray64[0] == arrayOfBitArray64[2]);
            Console.WriteLine("BitArray64[0] != BitArray64[2]: {0}", arrayOfBitArray64[0] != arrayOfBitArray64[2]);
        }

        private static void RandomFillBitArray64(BitArray64 bitArray, Random rand)
        {
            for (int i = 0; i < 64; i++)
            {
                bitArray[i] = (byte)(rand.Next() % 2);
            }
        }
    }
}