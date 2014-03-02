// 2. Implement a set of extension methods for IEnumerable<T> that implement
//    the following group functions: sum, product, min, max, average.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.IEnumerableExtends
{
    public static class IEnumerableExtends
    {
        // Return min element of the IEnumerable<T> 
        public static T Min<T>(this IEnumerable<T> lst) where T : IComparable
        {
            bool isFirstRepeat = true;
            T min = default(T);

            foreach (var item in lst)
            {
                if (isFirstRepeat)
                {
                    min = item;
                    isFirstRepeat = false;
                    continue;
                }

                if (min.CompareTo(item) > 0)
                {
                    min = item;
                }

            }
            return min;
        }

        // Return max element of the IEnumerable<T> 
        public static T Max<T>(this IEnumerable<T> lst) where T : IComparable
        {
            bool isFirstRepeat = true;
            T min = default(T);

            foreach (var item in lst)
            {
                if (isFirstRepeat)
                {
                    min = item;
                    isFirstRepeat = false;
                    continue;
                }

                if (min.CompareTo(item) < 0)
                {
                    min = item;
                }

            }
            return min;
        }

        // Return average amount of IEnumerable<T>
        public static T Avrg<T>(this IEnumerable<T> lst)
        {
            decimal sum = 0;
            int count = 0;

            // Catch the exceptions in case of not a number value
            try
            {
                foreach (var item in lst)
                {
                    sum += (decimal)((dynamic)item);
                    count++;
                }

                return (T)((dynamic)(sum / count));
            }
            catch (Exception)
            {
                throw new ArithmeticException("Some of the lists elements is not a number!");
            }
        }

        // Return the sum of IEnumerable<T> values
        public static T Sum<T>(this IEnumerable<T> lst)
        {
            decimal sum = 0;

            // Catch the exceptions in case of not a number value
            try
            {
                foreach (var item in lst)
                {
                    sum += (decimal)(dynamic)item;
                }

                return (T)(dynamic)sum;
            }
            catch (Exception)
            {
                throw new ArithmeticException("Some of the lists elements is not a number!");
            }
        }

        // Return the product of IEnumerable<T> values
        public static T Prod<T>(this IEnumerable<T> lst)
        {
            decimal prod = 1;

            // Catch the exceptions in case of not a number value
            try
            {
                foreach (var item in lst)
                {
                    prod *= (decimal)(dynamic)item;
                }

                return (T)(dynamic)prod;
            }
            catch (Exception)
            {
                throw new ArithmeticException("Some of the lists elements is not a number!");
            }
        }
    }
}