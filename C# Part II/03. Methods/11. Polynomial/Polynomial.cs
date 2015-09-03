// 11. Write a method that adds two polynomials. Represent them as arrays
// of their coefficients as in the example below: x2 + 5 = 1x2 + 0x + 5 -> 501

// 12. Extend the program to support also subtraction and multiplication of polynomials.

using System;
using System.Globalization;
using System.Text;
using System.Threading;

public class Polynomial
{
    // Sum or subtract 2 polynomials. The operation between p1 and p2 could be "+" or "-"
    private static decimal[] AddPolynomial(decimal[] p1, string operation, decimal[] p2)
    {
        int sign = 1;
        int oprtn = 1;

        // Swap polynomials if p2>p1 and change the sign
        if (p2.Length > p1.Length)
        {
            var tmp = p1;
            p1 = p2;
            p2 = tmp;
            sign = -1;
        }

        // Check operation to determine sign
        if (operation == "+")
        {
            sign = 1;
            oprtn = -1;
        }

        // Create result array
        decimal[] p = new decimal[p1.Length];

        // Calculate element by element
        for (int i = 0, j = 0; i < p1.Length; i++)
        {
            if (i >= p1.Length - p2.Length)
            {
                // Sum or subtract depending of operation
                p[i] = (sign * p1[i]) - (oprtn * sign * p2[j]);
                j++;
            }
            else
            {
                // If p1 longer then p2
                p[i] = sign * p1[i];
            }
        }

        // Return the result
        return p;
    }

    // Multiply polynomials. Result is egual to p1*p2
    private static decimal[] MultiplyPolynomial(decimal[] p1, decimal[] p2)
    {
        // Create result array - size is p1.length+p2.length-1
        decimal[] p = new decimal[p1.Length + p2.Length - 1];

        for (int i = 0; i < p1.Length; i++)
        {
            for (int ii = 0; ii < p2.Length; ii++)
            {
                // Multiply coeficients and sum with already 
                // calculated coeficients of the same power
                p[i + ii] += p1[i] * p2[ii];
            }
        }

        // Return the result
        return p;
    }

    // Convert polynomial to string
    private static string PolynomialToString(decimal[] p)
    {
        // Use StringBuilder to semplify creation of string
        StringBuilder str = new StringBuilder();

        for (int i = 0; i < p.Length; i++)
        {
            // Don't process 0 coeficients
            if (p[i] == 0) { continue; }

            // Manage first negative coeficient
            if (p[i] < 0)
            {
                if (str.Length == 0) { str.Append("-"); }
                else { str.Append(" - "); }
            }
            else
            {
                if (str.Length != 0) { str.Append(" + "); }
            }

            // Instead of x^1 and x^0 print just x or just coeficient
            if (i == p.Length - 2)
            {
                str.Append(string.Format("{0}*x", Math.Abs(p[i])));
            }
            else if (i == p.Length - 1)
            {
                str.Append(string.Format("{0}", Math.Abs(p[i])));
            }
            else
            {
                str.Append(string.Format("{0}*x^{1}", Math.Abs(p[i]), p.Length - i - 1));
            }
        }

        // Return the result
        if (str.Length == 0) { return "0"; }
        else { return str.ToString(); }
    }

    // Input polynomials
    private static decimal[] InputPolynomial(int num)
    {
        Console.Write("Enter highest power of x for polinomial P{0}: ", num);
        int sizeP = int.Parse(Console.ReadLine());

        // Size of rezult is max power of x + 1
        decimal[] p = new decimal[++sizeP];

        // Input all coeficients
        for (int i = 0; i < sizeP; i++)
        {
            Console.Write("Enter the coeficient before x^{0} : ", sizeP - i - 1);
            p[i] = decimal.Parse(Console.ReadLine());
        }

        return p;
    }

    public static void Main()
    {
        // Set the curent culture to invariante to use "." instate of ","
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        // Create polynomial p1
        decimal[] p1 = InputPolynomial(1);
        Console.WriteLine();

        // Create polynomial p2
        decimal[] p2 = InputPolynomial(2);
        Console.WriteLine();
        Console.WriteLine("---------------------------------------------------------------------");

        // Print polynomials
        Console.WriteLine("Polynomial P1: {0}", PolynomialToString(p1));
        Console.WriteLine("Polynomial P2: {0}", PolynomialToString(p2));
        Console.WriteLine("---------------------------------------------------------------------");
        Console.WriteLine();

        // Add p1+p2 and print the result
        decimal[] p3 = AddPolynomial(p1, "+", p2);
        Console.WriteLine("P1 + P2 = : {0}", PolynomialToString(p3));
        Console.WriteLine();

        // Subtract p1-p2 and print the result
        p3 = AddPolynomial(p1, "-", p2);
        Console.WriteLine("P1 - P2 = : {0}", PolynomialToString(p3));
        Console.WriteLine();

        // Subtract p2-p1 and print the result
        p3 = AddPolynomial(p2, "-", p1);
        Console.WriteLine("P2 - P1 = : {0}", PolynomialToString(p3));
        Console.WriteLine();

        // Multiply p1*p2 and print the result
        p3 = MultiplyPolynomial(p1, p2);
        Console.WriteLine("P1 * P2 = : {0}", PolynomialToString(p3));
        Console.WriteLine();
    }
}