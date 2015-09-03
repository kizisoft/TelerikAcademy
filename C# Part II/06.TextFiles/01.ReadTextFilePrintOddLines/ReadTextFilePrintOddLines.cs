using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReadTextFilePrintOddLines
{
    class ReadTextFilePrintOddLines
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\somefile.txt";
            Console.WriteLine("Contents of the odd lines in file {0}:", fileName);

            StreamReader reader = new StreamReader(fileName);
            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine("Line {0}: {1}", lineNumber, line);
                    }
                    line = reader.ReadLine();
                }
            }
        }
    }
}
