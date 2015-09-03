// Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.Palindromes
{
    class Palindromes
    {
        class PalindromeExtractor
        {
            private static bool IsPalindrome(string word)
            {
                for (int i = 0; i < word.Length / 2; i++)
                {
                    // When the middle is reached there is noneed to go on
                    if (word[i] != word[word.Length - i - 1])
                    {
                        return false;
                    }
                }

                return true;
            }

            static void Main()
            {
                string text = Console.ReadLine();
                char[] separators = { '.', ',', ' ', '!', '?', '-', '_' };
                string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    if (IsPalindrome(word))
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}