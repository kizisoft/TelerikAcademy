using System;

class NumbersToText
{
    // Create enumeration with all numbers
    enum Numbers
    {
        zero,
        one,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
        eleven,
        twelve,
        thirteen,
        fourteen,
        fifteen,
        sixteen,
        seventeen,
        eighteen,
        nineteen,
        twenty,
        thirty = 30,
        forty = 40,
        fifty = 50,
        sixty = 60,
        seventy = 70,
        eighty = 80,
        ninety = 90,
        One = 100,
        Two = 200,
        Three = 300,
        Four = 400,
        Five = 500,
        Six = 600,
        Seven = 700,
        Eight = 800,
        Nine = 900,
    }

    static void Main()
    {
        int i100, i10, i1;
        string str;

        // Input a number
        Console.Write("Input number (0...999): ");
        int num = int.Parse(Console.ReadLine());

        i1 = num % 10;              // Calculate units
        i10 = num % 100 - i1;       // Calculate tens
        i100 = num - i10 - i1;      // Calculate hundreds

        // Compute the text number
        if (i100 + i10 == 0)
        {
            str = ((Numbers)i1).ToString();
        }
        else if (i10 + i1 == 0)
        {
            str = ((Numbers)i100).ToString() + " hundred";
        }
        else if (i100 + i1 == 0)
        {
            str = ((Numbers)i10).ToString();
        }
        else if (i100 == 0)
        {
            if (num < 20)
            {
                str = ((Numbers)num).ToString();
            }
            else
            {
                str = ((Numbers)i10).ToString() + " " + ((Numbers)i1).ToString();
            }
        }
        else if (i10 == 0)
        {
            str = ((Numbers)i100).ToString() + " hundred and " + ((Numbers)i1).ToString();
        }
        else if (i1 == 0)
        {
            str = ((Numbers)i100).ToString() + " hundred and " + ((Numbers)i10).ToString();
        }
        else
        {
            if (i10 + i1 < 20)
            {
                str = ((Numbers)i100).ToString() + " hundred and " + ((Numbers)(i10 + i1)).ToString();
            }
            else
            {
                str = ((Numbers)i100).ToString() + " hundred and " + ((Numbers)i10).ToString() + " " + ((Numbers)i1).ToString();
            }
        }

        // Print the text number
        Console.WriteLine(str);
    }
}