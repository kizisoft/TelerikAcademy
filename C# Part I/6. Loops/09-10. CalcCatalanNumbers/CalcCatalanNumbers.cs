using System;
using System.Numerics;

class CalcCatalanNumbers
{
    static void Main()
    {
        // Input N
        Console.Write("Input N: ");
        int n = int.Parse(Console.ReadLine());

        // Store the factoriel result in the very big integer type
        BigInteger bigIntFact2N = 1;
        BigInteger bigIntFactN = 1;

        // Calc (2*N)!
        for (int i = 1; i <= 2 * n; i++)
        {
            bigIntFact2N = bigIntFact2N * i;
            if (i == n)
            {
                bigIntFactN = bigIntFact2N;
            }
        }

        // Print the result
        Console.WriteLine("The {0} Calatan number  = {1}", n, bigIntFact2N / (bigIntFactN * bigIntFactN * (n + 1)));
    }
}