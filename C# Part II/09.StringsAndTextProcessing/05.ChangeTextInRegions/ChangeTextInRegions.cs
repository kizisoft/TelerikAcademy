// You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. Example:
// We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
// The expected result:
// We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ChangeTextInRegions
{
    class ChangeTextInRegions
    {
        static void Main()
        {
            string inputText = Console.ReadLine();
            Console.WriteLine(ToUpperCase(inputText));
        }

        static string ToUpperCase(string input)
        {
            // Split the text into parts before and after < and > tags
            string[] splittext = input.Split('<', '>');
            StringBuilder result = new StringBuilder(input.Length);

            for (int i = 0; i < splittext.Length; i++)
            {
                // If there the text part is not start or end region word, print as it is
                if (splittext[i] != "upcase" && splittext[i] != "/upcase")
                {
                    result.Append(splittext[i]);
                }

                // If there is start region word print the next text part to upper case
                else if (splittext[i] == "upcase")
                {
                    result.Append((splittext[i + 1].ToString().ToUpper()));
                    i++;
                }

            }

            // Return the result
            return result.ToString();
        }
    }
}