using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SortStrings
{
    class SortStrings
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\names.txt";
            StreamReader reader = new StreamReader(fileName);
            List<string> namesList = new List<string>();
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    namesList.Add(line);
                    line = reader.ReadLine();
                }
            }
            namesList.Sort();
            string outputFile = @"..\..\namesSorted.txt";
            StreamWriter streamWriter = new StreamWriter(outputFile);
            using (streamWriter)
            {
                for (int i = 0; i < namesList.Count; i++)
                {
                    streamWriter.WriteLine(namesList[i]);
                }
            }
        }
    }
}
