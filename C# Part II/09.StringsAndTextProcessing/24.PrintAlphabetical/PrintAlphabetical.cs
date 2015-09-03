// Write a program that reads a list of words, separated by spaces and
// prints the list in an alphabetical order.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24.PrintAlphabetical
{
    class PrintAlphabetical
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> textFormated = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                // If the word is already added, do not add it again to avoid repetitions
                if (!textFormated.Contains(words[i]))
                {
                    textFormated.Add(words[i]);
                }
            }

            textFormated.Sort();

            foreach (var word in textFormated)
            {
                Console.WriteLine(word);
            }
        }
    }
}