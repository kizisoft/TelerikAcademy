// Write a program that reads a string from the console and prints all different letters
// in the string along with information how many times each letter is found. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.CountLetters
{
    class CountLetters
    {
        static void Main()
        {
            // Use Dictionaty to store statistic of repetitions
            // first falue is a key (uniq element), second is number of repetitions
            Dictionary<char, int> statistic = new Dictionary<char, int>();

            // Input the string
            Console.Write("Input the string: ");
            string strIn = Console.ReadLine();

            // Count letters
            for (int i = 0; i < strIn.Length; i++)
            {
                // Count only letters
                if (!char.IsLetter(strIn[i]))
                {
                    continue;
                }

                // Create statistics of elements repetitions
                if (statistic.ContainsKey(strIn[i]))
                {
                    // Increase repetitions of element if exist
                    statistic[strIn[i]]++;
                }
                else
                {
                    // Add element to the dictionary if not exist
                    statistic.Add(strIn[i], 1);
                }
            }

            // Print letters statistics
            foreach (var item in statistic)
            {
                Console.WriteLine("Letter \"{0}\" -> {1}", item.Key, item.Value);
            }
        }
    }
}
