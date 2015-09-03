// Write a method that adds two positive integer numbers represented as
// arrays of digits (each array element arr[i] contains a digit; the last
// digit is kept in arr[0]). Each of the numbers that will be added could
// have up to 10 000 digits.

using System;
using System.Collections.Generic;
using System.Text;

namespace SumBiggerNumbers
{
    // Create aa class to store and sum big numbers
    public class BigNumbers
    {
        // Private field to store the big number
        private byte[] bigNumber;

        // Property to read and set value of the big number
        public byte[] BigNumber
        {
            get { return (byte[])bigNumber.Clone(); }           // Return a new copy of the value      
            set { bigNumber = (byte[])value.Clone(); }          // Set a new big number
        }

        // Constructor - create a BigNumber object
        public BigNumbers(byte[] bigNumber)
        {
            // Initialize a big number
            this.bigNumber = (byte[])bigNumber.Clone();
            Array.Reverse(this.bigNumber);
        }

        // Create operator + to sum tow big numbers
        public static BigNumbers operator +(BigNumbers num1, BigNumbers num2)
        {
            // Always longer number is stored in num1
            int len = GetLength(ref num1, ref num2);

            // Initialize a remainder
            int remainder = 0;

            // Accumulate curent sum in result list
            List<byte> res = new List<byte>();

            for (int i = 0; i < len; i++)
            {
                if (i < num2.bigNumber.Length)
                {
                    remainder += num1.bigNumber[i] + num2.bigNumber[i];
                }
                else
                {
                    remainder += num1.bigNumber[i];
                }

                // Add curent digith to the list
                res.Add((byte)(remainder % 10));

                // Calculate the remainder
                if (remainder >= 10)
                {
                    remainder = 1;
                }
                else
                {
                    remainder = 0;
                }
            }

            // Add remainder
            if (remainder != 0)
            {
                res.Add(1);
            }

            // Return the result of sum
            res.Reverse();
            return new BigNumbers(res.ToArray());
        }

        // Always longer number is stored in num1
        private static int GetLength(ref BigNumbers num1, ref BigNumbers num2)
        {
            int len;
            if (num1.bigNumber.Length >= num2.bigNumber.Length)
            {
                // Length is the maximal length
                len = num1.bigNumber.Length;
            }
            else
            {
                // if num2 length > num1 length then swap num1 and num2
                len = num2.bigNumber.Length;
                BigNumbers tmp = num1;
                num1 = num2;
                num2 = tmp;
            }
            return len;
        }

        // Override method ToString to print the number
        public override string ToString()
        {
            // Use a StringBuilder to optimize creation of string
            StringBuilder str = new StringBuilder();
            for (int i = this.bigNumber.Length - 1; i >= 0; i--)
            {
                str.Append(bigNumber[i]);
            }

            //Return the result string
            return str.ToString();
        }

        // Create operator * to multiplay tow big numbers
        public static BigNumbers operator *(BigNumbers num1, BigNumbers num2)
        {
            // Always longer number is stored in num1
            int len = GetLength(ref num1, ref num2);

            BigNumbers val = new BigNumbers(new byte[] { 0 });

            for (int i = 0; i < num2.bigNumber.Length; i++)
            {
                // Accumulate curent value in result list
                List<byte> res = new List<byte>();

                // Store the remainder
                int remainder = 0;

                for (int j = 0; j < len; j++)
                {
                    remainder += num1.bigNumber[j] * num2.bigNumber[i];

                    // Add curent digith to the list
                    res.Add((byte)(remainder % 10));

                    // Calculate the remainder
                    remainder = (remainder - (remainder % 10)) / 10;
                }

                // Add remainder
                if (remainder != 0)
                {
                    res.Add((byte)remainder);
                }

                res.Reverse();

                for (int zeros = 0; zeros < i; zeros++)
                {
                    res.Add(0);
                }


                val += new BigNumbers(res.ToArray());
            }

            // Return the result of multyplay
            return val;
        }
    }

    public class SumBiggerNumbers
    {
        static void Main()
        {
            // Create 3 BigNumber
            // This number could be verry big
            BigNumbers num1 = new BigNumbers(new byte[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 });
            // This one also
            BigNumbers num2 = new BigNumbers(new byte[] { 9, 9, 9, 9, 9 });
            BigNumbers num3 = num1 + num2;

            // Print BigNumber
            Console.WriteLine("BigNumber #1 = {0}", num1);
            Console.WriteLine("BigNumber #2 = {0}", num2);
            Console.WriteLine("BigNumber #3: (#1 + #2) = {0}", num3);

            // Sum
            num3 = num1;
            num3 += num1;

            // Print
            Console.WriteLine("BigNumber #3: (#1 + #1) = {0}", num3);
        }
    }
}