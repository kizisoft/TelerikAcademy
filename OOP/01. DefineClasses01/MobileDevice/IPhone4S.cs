using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MobileDevice
{
    public static class IPhone4S
    {
        private static List<string> iPhone4S;

        static IPhone4S()
        {
            iPhone4S = new List<string>();

            using (StreamReader sr = new StreamReader("..\\..\\iPhone4S.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    iPhone4S.Add(sr.ReadLine());
                }
            }
        }

        public static string GetInfo()
        {
            StringBuilder sb = new StringBuilder("--= IPhone 4S =--");
            sb.Append(Environment.NewLine);

            foreach (var item in iPhone4S)
            {
                sb.Append(item);
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}