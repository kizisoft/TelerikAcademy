// 6. Write a program that prints from given array of integers all numbers
//    that are divisible by 7 and 3. Use the built-in extension methods and
//    lambda expressions. Rewrite the same with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.DivisibleNumbers
{
    class DivisibleNumbers
    {
        static void Main(string[] args)
        {
            // Create a new array of int
            int[] numbArray = new int[100];

            // Fill the array with numbers from 1 to 100
            for (int i = 1; i < 101; i++)
            {
                numbArray[i - 1] = i;
            }

            // Extension method implementation
            var res = numbArray.Where(x => x % 7 == 0 && x % 3 == 0);

            Console.WriteLine("Numbers from 1 to 100 divisible by 7 and 3 (Extension): {{ {0} }}", string.Join(", ", res));

            // LINQ implementation
            res = from numb in numbArray
                  where numb % 7 == 0 && numb % 3 == 0
                  select numb;

            Console.WriteLine("Numbers from 1 to 100 divisible by 7 and 3 (LINQ): {{ {0} }}", string.Join(", ", res));
        }
    }
}