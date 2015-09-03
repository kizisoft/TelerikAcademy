using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SquareMatrix
{
    class SquareMatrix
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\matrix.txt";
            StreamReader reader = new StreamReader(fileName);
            int matrixSize;
            int[,] matrix;
            string line;
            int row = 0;
            using (reader)
            {
                matrixSize = int.Parse(reader.ReadLine());
                matrix = new int[matrixSize, matrixSize];
                line = reader.ReadLine();
                while (line != null)
                {
                    int col = 0;
                    for (int i = 0; i < line.Length; i++)
                    {
                        int currentSymbol = (int)line[i];
                        if (currentSymbol == 32)
                        {
                            continue;
                        }
                        matrix[row, col] = currentSymbol - '0';
                        Console.Write("{0} ", matrix[row, col]);//test
                        col++;
                    }
                    Console.WriteLine();//test
                    row++;
                    line = reader.ReadLine();
                }
            }
            int subMatrixSize = 2;
            int maxSum = GetMaxSum2x2(matrix, subMatrixSize);
            string outputFile = @"..\..\maxSum2x2.txt";
            StreamWriter streamWriter = new StreamWriter(outputFile);
            using (streamWriter)
            {
                streamWriter.Write(maxSum);
            }
        }

        private static int GetMaxSum2x2(int[,] matrix, int subMatrixSize)
        {
            int maxSum = int.MinValue;
            int startSubMatrix = 0;
            int endSubMatrix = 0;
            int currentRow = 0;
            int subMatrixRowStart = 0;
            while (currentRow <= matrix.GetLength(0) - subMatrixSize)
            {
                for (int colStart = 0; colStart <= matrix.GetLength(1) - subMatrixSize; colStart++)
                {
                    int sum = 0;
                    for (int subMatrixRow = currentRow; subMatrixRow <= currentRow + (subMatrixSize - 1); subMatrixRow++)
                    {
                        for (int subMatrixCol = colStart; subMatrixCol <= colStart + (subMatrixSize - 1); subMatrixCol++)
                        {
                            sum = sum + matrix[subMatrixRow, subMatrixCol];
                        }
                    }
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        subMatrixRowStart = currentRow;
                        startSubMatrix = colStart;
                        endSubMatrix = colStart + (subMatrixSize - 1);
                    }
                }
                currentRow++;
            }
            return maxSum;
        }
    }
}
