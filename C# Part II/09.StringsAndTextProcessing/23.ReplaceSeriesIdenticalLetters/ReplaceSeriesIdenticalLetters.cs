// Write a program that reads a string from the console and replaces all series
// of consecutive identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.ReplaceSeriesIdenticalLetters
{
    class ReplaceSeriesIdenticalLetters
    {
        static void Main()
        {
            string text = Console.ReadLine();
            StringBuilder textFormated = new StringBuilder();
            char letter = text[0];
            textFormated.Append(text[0]);
            for (int i = 0; i < text.Length; i++)
            {
                // If the next letter is the same don't add it
                if (letter == text[i])
                {
                    continue;
                }
                else
                {
                    // Add only the first time a letter is reached
                    textFormated.Append(text[i]);
                    letter = text[i];
                }
            }

            Console.WriteLine(textFormated);
        }
    }
}