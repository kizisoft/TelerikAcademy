using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ConcatenateTextFiles
{
    class ConcatenateTextFiles
    {
        static void Main(string[] args)
        {
            string fileName1 = @"..\..\file1.txt";
            string fileName2 = @"..\..\file2.txt";
            StreamReader reader1 = new StreamReader(fileName1);
            StreamReader reader2 = new StreamReader(fileName2);
            string fileName1and2 = @"..\..\file1and2.txt";

            string filesContents;
            using (reader1)
            {
                filesContents = reader1.ReadToEnd();
            }
            using (reader2)
            {
                filesContents = filesContents + reader2.ReadToEnd();
            }

            StreamWriter streamWriter = new StreamWriter(fileName1and2);
            using (streamWriter)
            {
                streamWriter.Write(filesContents);
            }
            Console.WriteLine("File is written!");
        }
    }
}
