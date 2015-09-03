using System;

class SumStringNumbers
{
    static void Main()
    {
        // Input a string of numbers separated by Space
        Console.Write("Input a few interger numbers separated by SPACE: ");
        string strIn = Console.ReadLine();

        //Call a method to calc the sum of entered numbers
        Console.WriteLine("The sum ot numbers: {0}", SumStrNums(strIn));
    }

    //Calculate the sum of given as string numbers
    private static long SumStrNums(string strIn)
    {
        // Split the string
        string[] strInArray = strIn.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Calculate the sum
        long sum = 0;
        for (int i = 0; i < strInArray.Length; i++)
        {
            sum += int.Parse(strInArray[i]);
        }

        // Return the results 
        return sum;
    }
}
