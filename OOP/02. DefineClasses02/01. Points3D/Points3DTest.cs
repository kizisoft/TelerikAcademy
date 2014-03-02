using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01.Points3D
{
    public static class Points3DTest
    {
        static void Main(string[] args)
        {
            // Set the curent culture to invariante to use "." instate of ","
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Test creation of points, point zero and path of points
            Points3DPath.PointsPath path = new Points3DPath.PointsPath();
            path.AddPoint(new Point3D(3.4f, 4.3f, 2.3f));
            path.AddPoint(Point3D.PointZero);
            path.AddPoint(new Point3D(23.4f, 42.3f, 32.3f));
            Console.WriteLine("Curent path:");
            Console.WriteLine(path);

            // Test calculation of distance
            Console.WriteLine();
            Console.WriteLine("Distance between:");
            Console.WriteLine("{0} and", path.Path[0]);
            Console.WriteLine(path.Path[2]);
            Console.WriteLine("Distance = {0}", Points3DCalculations.DistanceCalculations.CalcDistance(path.Path[0], path.Path[2]));

            // Test save and load of points
            Console.WriteLine();
            Console.Write("Saving a path to PathFile.3dp file    ");
            FunLoading();
            Points3DPath.Points3DPathStorage.WritePoints3DPath(path, "PathFile.3dp");
            Console.Write("Clearing the path object    ");
            FunLoading();
            path = new Points3DPath.PointsPath();
            Console.Write("Loading a path from PathFile.3dp file    ");
            FunLoading();
            path = Points3DPath.Points3DPathStorage.ReadPoints3DPath("PathFile.3dp");
            Console.WriteLine();
            Console.WriteLine("Curent path:");
            Console.WriteLine(path);
        }

        // Just for fun ;)
        public static void FunLoading()
        {
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}{1}{2}. {3}%", (char)ConsoleKey.Backspace, (char)ConsoleKey.Backspace, (char)ConsoleKey.Backspace, (i + 1) * 10);
                Thread.Sleep(rnd.Next(120, 201));
            }

            Console.WriteLine(" completed.");
        }
    }
}