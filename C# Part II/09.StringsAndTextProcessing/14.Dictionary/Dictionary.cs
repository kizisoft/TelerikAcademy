// A dictionary is stored as a sequence of text lines containing words and their explanations.
// Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
// .NET – platform for applications from Microsoft
// CLR – managed execution environment for .NET
// namespace – hierarchical organization of classes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Dictionary
{
    class Dictionary
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            while (true)
            {
                Console.WriteLine("Enter word: ");
                string key = Console.ReadLine();

                // For end enter Spacebar
                if (key == " ")
                {
                    break;
                }

                Console.WriteLine("Enter translation: ");
                string value = Console.ReadLine();
                dictionary.Add(key, value);
            }

            foreach (var item in dictionary.Keys)
            {
                string word = item;
                string translation = dictionary[item];
                Console.WriteLine("{0} - {1}", word, translation);
            }
        }
    }
}