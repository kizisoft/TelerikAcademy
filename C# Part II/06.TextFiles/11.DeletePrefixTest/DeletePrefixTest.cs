using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _11.DeletePrefixTest
{
    class DeletePrefixTest
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\somefile.txt";
            StreamReader reader = new StreamReader(fileName);

            string text = "";
            string pattern = @"(?<text>test.*\s)";
            using (reader)
            {
                text = reader.ReadToEnd();
                Match parse = Regex.Match(text, pattern);
                while (parse.Success)
                {
                    text = text.Replace(parse.Groups["text"].Value, "");
                    parse = parse.NextMatch();
                }

            }
            string fileNameNew = @"..\..\somefileNew.txt";
            StreamWriter writer = new StreamWriter(fileNameNew);
            using (writer)
            {
                writer.Write(text);
            }
        }
    }
}
