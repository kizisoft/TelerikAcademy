// Write a program for extracting all email addresses from given text. All substrings
// that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _18.ExtractEmails
{
    class ExtractEmails
    {
        static void Main()
        {
            Console.Write("Input a text: ");
            string sampleText = Console.ReadLine();
            string pattern = @"([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})";

            MatchCollection results = Regex.Matches(sampleText, pattern);

            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}