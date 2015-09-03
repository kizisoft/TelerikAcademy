// Write a program that extracts from a given text all sentences containing given word.
//
//		Example: The word is "in". The text is:
//               We are living in a yellow submarine. We don't have anything else. Inside the submarine
//               is very tight. So we are drinking all the day. We will move out of it in 5 days.
//
// The expected result is:
//      We are living in a yellow submarine.
//      We will move out of it in 5 days
//
// Consider that the sentences are separated by "." and the words – by non-letter symbols.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ExtractSentences
{
    class ExtractSentences
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some text: ");
            string inputText = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter required word: ");
            string word = Console.ReadLine();
            Console.WriteLine();

            // Split the text into sentances
            string[] allSentances = inputText.Split('.');
            StringBuilder outputText = new StringBuilder();

            foreach (string sentance in allSentances)
            {
                StringBuilder currnetWord = new StringBuilder();

                foreach (var symbol in sentance)
                {
                    // Build words of symbols and check for the required one
                    if ((symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z'))
                    {
                        currnetWord.Append(symbol);
                    }
                    else
                    {
                        if (currnetWord.ToString().ToLower() == word.ToLower())
                        {
                            string sentanceFinal = sentance + ".";

                            // Remove leading and trailing white-spaces 
                            outputText.AppendLine(sentanceFinal.Trim());

                            // Go to the next sentance
                            break;
                        }

                        // If current symbol is not a letter then the word is finished and have to be started new word
                        currnetWord.Clear();
                    }
                }
            }

            Console.WriteLine(outputText);
        }
    }
}