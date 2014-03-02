// 3. Write a static class with a static method to calculate
//    the distance between two points in the 3D space.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Points3D.Points3DCalculations
{
    public static class DistanceCalculations
    {
        public static float CalcDistance(Point3D pointA, Point3D pointB)
        {
            // Return the Euclidean distance
            return (float)Math.Sqrt(
                (pointA.X - pointB.X) * (pointA.X - pointB.X) +
                (pointA.Y - pointB.Y) * (pointA.Y - pointB.Y) +
                (pointA.Z - pointB.Z) * (pointA.Z - pointB.Z)
                );
        }
    }
}