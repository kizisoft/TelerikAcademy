using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.ReplaceStartWithFinish
{
    class ReplaceStartWithFinish
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\StartFinish.txt";
            StreamReader reader = new StreamReader(fileName);
            string outputFile = @"..\..\StartFinishNew.txt";
            StreamWriter streamWriter = new StreamWriter(outputFile);
            using (reader)
            {
                string line = reader.ReadLine();                    
                while (line != null)
                {
                    line = line.Replace("start", "finish");
                    streamWriter.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
            streamWriter.Close();
        }
    }
}
