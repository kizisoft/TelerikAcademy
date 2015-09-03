// 14. Write methods to calculate minimum, maximum, average, sum and product
// of given set of integer numbers. Use variable number of arguments.
//
// 15.* Modify your last program and try to make it work for any number type,
// not just integer (e.g. decimal, float, byte, etc.). Use generic method
// (read in Internet about generic methods in C#).

using System;
using System.Linq;

namespace ManageNumbers
{
    public class ManageNumbers
    {
        // Calculate min element
        public static dynamic MinNumbers<T>(params T[] num)
        {
            return num.Min();
        }

        // Calculate max element
        public static dynamic MaxNumbers<T>(params T[] num)
        {
            return num.Max();
        }

        // Return average of elements, it depend of data type
        public static dynamic AvrgNumbers<T>(params T[] num)
        {
            if (num.Length == 0) return 0;

            dynamic sum = SumNumbers<T>(num);

            return sum / num.Length;
        }

        // Return a sum of elements. Use recursion to calc the sum
        public static dynamic SumNumbers<T>(params T[] num)
        {
            if (num.Length == 0) return 0;      // End of recursion

            return num[0] + SumNumbers<T>(num.Skip(1).ToArray());
        }

        // Return product of elements. Use recursion
        public static dynamic ProductNumbers<T>(params T[] num)
        {
            if (num.Length == 0) return 1;      // End of recursion

            return num[0] * ProductNumbers<T>(num.Skip(1).ToArray());
        }

        // Print test results
        private static void Print<T>(T[] val)
        {
            Console.WriteLine("------------------------------- {0} -------------------------------", typeof(T).Name);
            Console.WriteLine("{0}[{1}]{{{2}}}", typeof(T).Name, val.Length, string.Join(", ", val));
            Console.WriteLine();

            var res = MinNumbers(val);
            Console.WriteLine("Min element: {0}", res);

            res = MaxNumbers(val);
            Console.WriteLine("Max element: {0}", res);

            res = AvrgNumbers(val);
            Console.WriteLine("Average of the elements: {0}", res);

            res = SumNumbers(val);
            Console.WriteLine("Sum of the elements: {0}", res);

            res = ProductNumbers(val);
            Console.WriteLine("Product of the elements: {0}", res);
            Console.WriteLine();
        }

        static void Main()
        {
            // Test integer numbers
            Print(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            // Test double numbers
            Print(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }
    }
}