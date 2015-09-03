// Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
//		Example: The target substring is "in". The text is as follows:
// We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
// The result is: 9.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CountSubsring
{
    class CountSubsring
    {
        static void Main()
        {
            Console.WriteLine("Enter initial string: ");
            string stringInitial = Console.ReadLine().ToLower();

            Console.WriteLine("Enter string to count: ");
            string stringToCount = Console.ReadLine().ToLower();

            int counter = 0;

            for (int i = 0; i < stringInitial.Length; i++)
            {
                i = stringInitial.IndexOf(stringToCount, i);

                // if the substring does not exist till the end
                // of the initial string break otherwise infinite loop will be caused
                if (i == -1)
                {
                    break;
                }

                counter++;
                i = i + stringToCount.Length;
            }

            Console.WriteLine("{0} is found {1} times", stringToCount, counter);
        }
    }
}