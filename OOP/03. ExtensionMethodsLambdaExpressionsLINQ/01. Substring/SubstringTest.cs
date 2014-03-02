using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Substring
{
    class SubstringTest
    {
        static void Main(string[] args)
        {
            // Create test strings
            string str1 = "This is string!";
            StringBuilder str2 = new StringBuilder("This is StringBuilder!");

            // Use StringBuilderExtends to print the substring
            Console.WriteLine(str1.Substring(8, 6));
            Console.WriteLine(str2.Substring(8, 13));
        }
    }
}