using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CompareTextFiles
{
    class CompareTextFiles
    {
        static void Main(string[] args)
        {
            string fileName1 = @"..\..\file1.txt";
            string fileName2 = @"..\..\file2.txt";
            StreamReader reader1 = new StreamReader(fileName1);
            StreamReader reader2 = new StreamReader(fileName2);
            int countEqual = 0;
            int countDifferent = 0;
            string line1 = reader1.ReadLine();
            string line2 = reader2.ReadLine();
            while (line1 != null)
            {
                if (line1 == line2)
                {
                    countEqual++;
                }
                else
                {
                    countDifferent++;
                }
                line1 = reader1.ReadLine();
                line2 = reader2.ReadLine();
            }
            reader1.Close();
            reader2.Close();
            Console.WriteLine("Equal lines number -> {0}", countEqual);
            Console.WriteLine("Different lines number -> {0}", countDifferent);
        }
    }
}
