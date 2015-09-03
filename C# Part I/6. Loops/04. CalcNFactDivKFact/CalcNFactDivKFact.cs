using System;
using System.Numerics;

class CalcNFactDivKFact
{
    static void Main()
    {
        // Input number N
        Console.Write("Input number N: ");
        int n = int.Parse(Console.ReadLine());

        int k = 1;

        do
        {
            // Input number K
            Console.Write("Input number K(K<N): ");
            k = int.Parse(Console.ReadLine());
        } while (k > n);

        // Store the factoriel result in the very big integer type
        BigInteger bigIntRes = 1;

        // N!/K! = 1*2*...*K*K+1*...*N / 1*2*...*K = K+1*...*N
        for (int i = k + 1; i <= n; i++)
        {
            bigIntRes = bigIntRes * i;
        }

        // Print the result N!/K!
        Console.WriteLine("The result of N!/K! = {0}", bigIntRes);
    }
}