using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.IEnumerableExtends
{
    class IEnumerableExtendsTest
    {
        static void Main(string[] args)
        {
            // Create a new test list
            List<int> testList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Print the list and Sum, Prod, Min, Max and Avrg
            Console.WriteLine("Test list: {{ {0} }}", string.Join(", ", testList));
            Console.WriteLine("The sum of elements: {0}", testList.Sum());
            Console.WriteLine("The Product of elements: {0}", testList.Prod());
            Console.WriteLine("Min element: {0}", testList.Min());
            Console.WriteLine("Max element: {0}", testList.Max());
            Console.WriteLine("The average value: {0}", testList.Avrg());
        }
    }
}