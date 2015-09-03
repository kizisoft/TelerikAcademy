using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.DeleteOddLines
{
    class DeleteOddLines
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\somefile.txt";
            StreamReader reader = new StreamReader(fileName);
            List<string> newFileList = new List<string>();
            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 == 0)
                    {
                        newFileList.Add(line);
                    }
                    line = reader.ReadLine();
                }
            }
            StreamWriter writer = new StreamWriter(fileName, false);
            using (writer)
            {
                for (int i = 0; i < newFileList.Count; i++)
                {
                    writer.WriteLine(newFileList[i]);
                }
            }
        }
    }
}
