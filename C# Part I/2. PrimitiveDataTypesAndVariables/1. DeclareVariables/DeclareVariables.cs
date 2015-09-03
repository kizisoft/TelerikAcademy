using System;

class DeclareVariables
{
    static void Main()
    {
        // Declare variables
        byte b = 97;
        sbyte sb = -115;
        short sh = -10000;
        ushort ush = 52130;
        uint ui = 4825932;

        // Write variables and variable system type on the console
        Console.WriteLine(b.GetType().Name + " : " + b);
        Console.WriteLine(sb.GetType().Name + " : " + sb);
        Console.WriteLine(sh.GetType().Name + " : " + sh);
        Console.WriteLine(ush.GetType().Name + " : " + ush);
        Console.WriteLine(ui.GetType().Name + " : " + ui);
    }
}