// Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. Example:
// <html>
//   <head><title>News</title></head>
//   <body><p><a href="http://academy.telerik.com">Telerik
//     Academy</a>aims to provide free real-world practical
//     training for young people who want to turn into
//     skillful .NET software engineers.</p></body>
// </html>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25.ExtractTitleBodyFromHTML
{
    class ExtractTitleBodyFromHTML
    {
        static void Main(string[] args)
        {
            StringBuilder output = new StringBuilder();
            string line = null;
            string lineToLower = null;

            // If </html> this is the end of the document
            while (lineToLower != "</html>")
            {
                line = Console.ReadLine();
                lineToLower = line.ToLower();
                bool inTag = false;

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '>')
                    {
                        inTag = false;
                        continue;
                    }

                    if (inTag)
                    {
                        continue;
                    }

                    if (line[i] == '<')
                    {
                        inTag = true;
                        continue;
                    }

                    output.Append(line[i]);
                }

                output.Append('\n');
            }

            Console.WriteLine(output);
        }
    }
}