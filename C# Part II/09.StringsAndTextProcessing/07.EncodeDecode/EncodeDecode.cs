// Write a program that encodes and decodes a string using given encryption key (cipher).
// The key consists of a sequence of characters. The encoding/decoding is done by
// performing XOR (exclusive or) operation over the first letter of the string with the
// first of the key, the second – with the second, etc. When the last key character is
// reached, the next is the first.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.EncodeDecode
{
    class EncodeDecode
    {
        static void Main()
        {
            string inputText = Console.ReadLine();
            string cipher = Console.ReadLine();
            int cipherIndex = 0;
            StringBuilder encodedText = new StringBuilder(inputText.Length);

            for (int i = 0; i < inputText.Length; i++)
            {
                //Convert the char symbol from the string into number
                uint currentSymbol = Convert.ToUInt16(inputText[i]);
                uint cipherSymbol = Convert.ToUInt16(cipher[cipherIndex]);

                uint final = currentSymbol ^ cipherSymbol;

                //Convert the resulted number to char symbol
                char result = Convert.ToChar(final);
                encodedText.Append(result);

                if (cipherIndex == cipher.Length - 1)
                {
                    cipherIndex = 0;
                }
                else
                {
                    cipherIndex++;
                }
            }

            // Print the result
            Console.WriteLine(encodedText.ToString());
        }
    }
}