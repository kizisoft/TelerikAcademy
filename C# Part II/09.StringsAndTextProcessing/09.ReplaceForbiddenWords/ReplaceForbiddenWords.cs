// We are given a string containing a list of forbidden words and a text containing some of these words. Write a program that replaces the forbidden words with asterisks. Example:
// Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
// Words: "PHP, CLR, Microsoft"
//		The expected result:
// ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ReplaceForbiddenWords
{
    class ReplaceForbiddenWords
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some text: ");
            string text = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter forbiden words: ");
            string forbiddenWords = Console.ReadLine();
            Console.WriteLine();

            string[] forbiddenWordsSplitted = forbiddenWords.Split(',');

            for (int i = 0; i < forbiddenWordsSplitted.Length; i++)
            {
                string forbiddenWord = forbiddenWordsSplitted[i];

                // Remove leading and trailing white-spaces
                forbiddenWord = forbiddenWord.Trim();

                // Build the asterisks word with the same length
                string wordMask = new string('*', forbiddenWord.Length);

                // Replace forbidden word with asterisks word
                text = text.Replace(forbiddenWord, wordMask);
            }

            Console.WriteLine(text);
        }
    }
}