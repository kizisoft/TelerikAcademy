// Write a program that extracts from a given text all dates that match
// the format DD.MM.YYYY. Display them in the standard date format for Canada.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace _19.CanadaDates
{
    class CanadaDates
    {
        static void Main()
        {
            Console.Write("Input a text: ");
            string text = Console.ReadLine();

            Regex dateRegex = new Regex(@"(0?[1-9]|[12][0-9]|3[01])[.](0?[1-9]|1[012])[.]\d{4}");

            MatchCollection dates = dateRegex.Matches(text);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");

            StringBuilder output = new StringBuilder();

            foreach (var date in dates)
            {
                output.AppendLine(date.ToString());
            }

            Console.WriteLine(output);
        }
    }
}