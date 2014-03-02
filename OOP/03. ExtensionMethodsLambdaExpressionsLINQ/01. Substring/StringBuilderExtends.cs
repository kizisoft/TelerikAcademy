// 1. Implement an extension method Substring(int index, int length)
//    for the class StringBuilder that returns new StringBuilder and
//    has the same functionality as Substring in the class String.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Substring
{
    public static class StringBuilderExtends
    {
        // New extension method to implement behavior of string.Substring
        public static StringBuilder Substring(this StringBuilder str, int index, int length)
        {
            // Temporaly char array
            char[] newStr = new char[length];

            // Copy string to temp array
            str.CopyTo(index, newStr, 0, length);

            // Return new StringBuilder object
            return new StringBuilder(new string(newStr));
        }
    }
}