// Write a program that converts a string to a sequence of C# Unicode character literals.
// Use format strings. Sample input:
// Hi!
// Expected output:
// \u0048\u0069\u0021

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.StringToUnicode
{
    class StringToUnicode
    {
        static void Main()
        {
            Console.Write("Input a text: ");
            string text = Console.ReadLine();
            StringBuilder textUnicode = new StringBuilder(text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                // Cast char first ot int and then to unicode
                textUnicode.AppendFormat(@"\u{0:x4}", Convert.ToInt16(text[i]));
            }

            Console.WriteLine(textUnicode.ToString());
        }
    }
}