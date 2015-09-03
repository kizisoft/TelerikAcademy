//Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with '*'. Print the result string into the console.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ExpandTextWithStars
{
    class ExpandTextWithStars
    {
        static void Main()
        {
            // Input a text
            Console.Write("Input a text: ");
            string inputText = Console.ReadLine();

            // Create new StringBuilder
            StringBuilder outputText = new StringBuilder(20);

            if (inputText.Length > 20)
            {
                Console.WriteLine("Incorrect input!");
            }
            else
            {
                for (int i = 0; i < 20; i++)
                {
                    try
                    {
                        outputText.Append(inputText[i]);
                    }
                    catch
                    {
                        //If there are no more symbols in the input text add "*"
                        outputText.Append("*");
                    }
                }

                Console.WriteLine(outputText.ToString());
            }
        }
    }
}