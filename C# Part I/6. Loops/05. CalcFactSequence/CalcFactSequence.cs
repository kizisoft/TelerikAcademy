using System;
using System.Numerics;

class CalcFactSequence
{
    static void Main()
    {
        // Input number K
        Console.Write("Input number K: ");
        int k = int.Parse(Console.ReadLine());

        int n = 1;

        do
        {
            // Input number N
            Console.Write("Input number N(N<K): ");
            n = int.Parse(Console.ReadLine());
        } while (n > k);

        // Store the factoriel result in the very big integer type
        BigInteger bigIntFact = 1;
        bool flag = true;

        // N!*K! / (K-N)! = (1*2*...*K*K+1*...*N / (K-N)!) * (1*2*...*K) = ((K-N+1)*...*K) * (1*2*...*N)
        for (int i = 1; i <= n; i++)
        {
            bigIntFact = bigIntFact * i;
            if (flag && i == n)
            {
                i = k - n;
                n = k;
                flag = false;       // Flag to check if K-N < or > N
            }
        }

        // Print the result
        Console.WriteLine("The result of N!*K!/(K-N)! = {0}", bigIntFact);
    }
}