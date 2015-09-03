using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ReplaceWholeWord
{
    class ReplaceWholeWord
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\SomeFile.txt";
            StreamReader reader = new StreamReader(fileName);
            string outputFile = @"..\..\SomeFileNew.txt";
            StreamWriter streamWriter = new StreamWriter(outputFile);
            string startWord = "start ";
            string middleWord = " start ";
            string endWord = " start";
            string startWordNew = "finish ";
            string middleWordNew = " finish ";
            string endWordNew = " finish";
            using (reader)
            {
                string line = reader.ReadLine();
                int indexStartEnd;
                while (line != null)
                {
                    line = line.Replace(middleWord, middleWordNew);
                    indexStartEnd = line.IndexOf(startWord);
                    if (indexStartEnd == 0)
                    {
                        line = line.Replace(startWord, startWordNew);
                    }

                    indexStartEnd = line.IndexOf(endWord);
                    if (indexStartEnd == line.Length - endWord.Length)
                    {
                        line = line.Replace(endWord, endWordNew);
                    }

                    streamWriter.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
            streamWriter.Close();
        }
    }
}
