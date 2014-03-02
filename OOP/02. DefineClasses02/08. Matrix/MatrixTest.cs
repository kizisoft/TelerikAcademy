using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Matrix
{
    class MatrixTest
    {
        static void Main(string[] args)
        {
            Matrix<int> m1 = new Matrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Matrix<int> m2 = new Matrix<int>(new int[,] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } });

            Console.WriteLine("Matrix 1:");
            MatrixHasZero(m1);
            Console.WriteLine("Matrix 2:");
            MatrixHasZero(m2);

            Console.WriteLine("Matrix1 + Matrix2:");
            MatrixHasZero(m1 + m2);

            Console.WriteLine("Matrix1 - Matrix2:");
            MatrixHasZero(m1 - m2);

            Console.WriteLine("Matrix1 * Matrix2:");
            MatrixHasZero(m1 * m2);
        }

        private static void MatrixHasZero(Matrix<int> m)
        {
            Console.WriteLine(m);

            if (m)
            {
                Console.WriteLine("This matrix has only elements different from Zero!");
            }
            else
            {
                Console.WriteLine("This matrix has a Zero element!");
            }

            Console.WriteLine(Environment.NewLine);
        }
    }
}