// Write a program that finds all prime numbers in the range [1...10 000 000].
// Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

using System;
using System.Collections;

class PrimeNumbers
{
    static void Main()
    {
        int topCandidate = 10000000;        // 10 000 000
        int totalCount = 0;
        BitArray myBA1 = new BitArray(topCandidate + 1);

        /* Set all but 0 and 1 to prime status */
        myBA1.SetAll(true);
        myBA1[0] = myBA1[1] = false;

        /* Mark all the non-primes */
        int thisFactor = 2;
        int lastSquare = 0;
        int thisSquare = 0;

        while (thisFactor * thisFactor <= topCandidate)
        {
            /* Mark the multiples of this factor */
            int mark = thisFactor + thisFactor;
            while (mark <= topCandidate)
            {
                myBA1[mark] = false;
                mark += thisFactor;
            }

            /* Print the proven primes so far */
            thisSquare = thisFactor * thisFactor;
            for (; lastSquare < thisSquare; lastSquare++)
            {
                if (myBA1[lastSquare]) totalCount++;
            }

            /* Set thisfactor to next prime */
            thisFactor++;
            while (!myBA1[thisFactor]) { thisFactor++; }
        }

        /* Print the remaining primes */
        for (; lastSquare <= topCandidate; lastSquare++)
        {
            if (myBA1[lastSquare]) { totalCount++; }
        }

        Console.WriteLine("Total prime numbers in range [1...{0}] = {1}", topCandidate, totalCount);
    }
}