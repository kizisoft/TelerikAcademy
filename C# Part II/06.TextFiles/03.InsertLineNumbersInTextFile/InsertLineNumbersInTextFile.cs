using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.InsertLineNumbersInTextFile
{
    class InsertLineNumbersInTextFile
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\somefile.txt";
            StreamReader reader = new StreamReader(fileName);
            string fileNameNew = @"..\..\somefileNew.txt";
            StreamWriter streamWriter = new StreamWriter(fileNameNew);
            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    string newLine = lineNumber + ":" + line;
                    streamWriter.WriteLine(newLine);
                    line = reader.ReadLine();
                }
            }
            streamWriter.Close();
        }
    }
}
