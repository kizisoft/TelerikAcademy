using System;

class AddBonusScore
{
    static void Main()
    {
        int i = 0;

        // Input a number [0..9]
        Console.Write("Enter a number [1..9] = ");
        if (!int.TryParse(Console.ReadLine(), out i))           // Try to parse integer number, error if not
        {
            i = 10;
        }

        switch (i)
        {
            case 1:
            case 2:
            case 3: Console.WriteLine(i * 10);              // Range 1 ~ 3
                break;
            case 4:
            case 5:
            case 6: Console.WriteLine(i * 100);             // Range 4 ~ 6
                break;
            case 7:
            case 8:
            case 9: Console.WriteLine(i * 1000);            // Range 7 ~ 9
                break;
            default: Console.WriteLine("Error!");           // If the number is different of [1..9] or not a number print error message
                break;
        }
    }
}