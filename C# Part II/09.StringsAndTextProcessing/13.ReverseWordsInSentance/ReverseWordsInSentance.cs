// Write a program that reverses the words in given sentence.
//	Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.ReverseWordsInSentance
{
    class ReverseWordsInSentance
    {
        static void Main()
        {
            string sentance = Console.ReadLine();
            string[] words = sentance.Split(new char[] { ' ', '-', ',', ':', ';', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> sentanceReversed = new List<string>();

            for (int i = words.Length - 1; i >= 0; i--)
            {
                sentanceReversed.Add(words[i]);
                int lastIndexOf = sentance.LastIndexOf(words[i]);

                // In sentance will remain only the punctuation symbols
                sentance = sentance.Remove(lastIndexOf, words[i].Length);
            }

            int position = -1;
            int test = sentance.Length;

            for (int i = 0; i < sentance.Length - 1; i++)
            {
                string punctuation = Convert.ToString(sentance[i]);

                if (punctuation != " ")
                {
                    punctuation = punctuation + Convert.ToString(sentance[i + 1]);
                    i = i + 1;
                }

                position = position + 2;
                sentanceReversed.Insert(position, punctuation);
            }

            // Add the last punctuation symbol without white-space
            sentanceReversed.Add(Convert.ToString(sentance[sentance.Length - 1]));
            Console.WriteLine(string.Join("", sentanceReversed));
        }
    }
}