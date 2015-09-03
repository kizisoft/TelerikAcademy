using System;

class CheckPointInCircle
{
    static void Main()
    {
        const int circleX = 0;
        const int circleY = 0;
        const int circleR = 5;

        Console.Write("Input X coordinate of the point: ");
        int pointX = int.Parse(Console.ReadLine());     // Read point X coordinate

        Console.Write("Input Y coordinate of the point: ");
        int pointY = int.Parse(Console.ReadLine());     // Read point Y coordinate

        // Check if the point is in the circle
        bool isInsideCircle = ((circleX - circleR) <= pointX) && ((circleX + circleR) >= pointX) && ((circleY - circleR) <= pointY) && ((circleY + circleR) >= pointX);
        Console.WriteLine("The point with coordinate ({0},{1}) is in the cyrcle: {2}", pointX, pointY, isInsideCircle);
    }
}