// aWrite a program that reads a string from the console and lists all different
// words in the string along with information how many times each word is found.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22.CountWordsInText
{
    class CountWordsInText
    {
        static void Main()
        {
            // Use Dictionaty to store statistic of repetitions
            // first falue is a key (uniq element), second is number of repetitions
            Dictionary<string, int> statistic = new Dictionary<string, int>();

            // Input the string
            Console.Write("Input the string: ");
            string strIn = Console.ReadLine();

            StringBuilder word = new StringBuilder();

            // Count letters
            for (int i = 0; i < strIn.Length; i++)
            {
                // Count only letters
                if (char.IsLetter(strIn[i]))
                {
                    word = word.Append(strIn[i]);
                }
                else
                {
                    // Remove empty strings
                    if (word.ToString() == string.Empty)
                    {
                        continue;
                    }

                    // Create statistics of elements repetitions
                    if (statistic.ContainsKey(word.ToString()))
                    {
                        // Increase repetitions of element if exist
                        statistic[word.ToString()]++;
                    }
                    else
                    {
                        // Add element to the dictionary if not exist
                        statistic.Add(word.ToString(), 1);
                    }

                    // Start a new word
                    word.Clear();
                }
            }

            // Print letters statistics
            foreach (var item in statistic)
            {
                Console.WriteLine("\"{0}\" -> {1}", item.Key, item.Value);
            }
        }
    }
}
