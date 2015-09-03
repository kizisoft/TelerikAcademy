using System;

class IsInCircleOutOfRectangle
{
    static void Main()
    {
        // Declare circle coordinates
        const int circleX = 1;
        const int circleY = 1;
        const int circleR = 3;

        // Declare rectangle coordinates
        const int rectX = -1;
        const int rectY = 1;
        const int rectH = 2;
        const int rectW = 6;

        Console.Write("Input X coordinate of the point: ");
        int pointX = int.Parse(Console.ReadLine());     // Read point X coordinate

        Console.Write("Input Y coordinate of the point: ");
        int pointY = int.Parse(Console.ReadLine());     // Read point Y coordinate

        // Calculate if the point is in the circle
        bool isInCircle = ((circleX - circleR) <= pointX) && ((circleX + circleR) >= pointX) && ((circleY - circleR) <= pointY) && ((circleY + circleR) >= pointY);

        // Calculate if the point is out of the rectangle
        bool isOutRect = ((rectX < pointX) || ((rectX + rectW) > pointX)) && ((rectY < pointY) || ((rectY - rectH) > pointY));

        Console.WriteLine("The point with coordinate ({0},{1}) is in the cyrcle and out of triangle: {2}", pointX, pointY, isInCircle && isOutRect);
    }
}