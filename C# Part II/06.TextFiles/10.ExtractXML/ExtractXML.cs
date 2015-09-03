using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _10.ExtractXML
{
    class ExtractXML
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\somefile.xml";
            StreamReader reader = new StreamReader(fileName);
            using (reader)
            {
                string line = reader.ReadLine();
                int indexStart = 0;
                int indexEnd = 0;
                while (line != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        indexStart = line.IndexOf('<', indexEnd);
                        indexEnd = line.IndexOf('>', indexEnd + 1);
                        for (int j = indexStart + 1; j <= indexEnd - 1; j++)
                        {
                            Console.Write(line[j]);
                        }
                        Console.WriteLine();
                        i = indexEnd;
                    }
                    line = reader.ReadLine();
                }
            }
        }
    }
}
