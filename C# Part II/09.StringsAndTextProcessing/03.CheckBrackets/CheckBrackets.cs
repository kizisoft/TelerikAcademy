// Write a program to check if in a given expression the brackets are put correctly.
// Example of correct expression: ((a+b)/5-d).
// Example of incorrect expression: )(a+b)).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CheckBrackets
{
    class CheckBrackets
    {
        static void Main()
        {
            string expression = Console.ReadLine();
            int indexOpenBracket = expression.IndexOf('(');
            int indexCloseBracket = expression.IndexOf(')');

            if (indexCloseBracket < indexOpenBracket)
            {
                Console.WriteLine("Incorrect expression");
                return;
            }

            int countOpenBracket = 0;
            int coutnCloseBracket = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    countOpenBracket++;
                }

                if (expression[i] == ')')
                {
                    coutnCloseBracket++;
                }
            }

            if (countOpenBracket == coutnCloseBracket)
            {
                Console.WriteLine("Correct expression");
            }
            else
            {
                Console.WriteLine("Incorrect expression");
            }
        }
    }
}