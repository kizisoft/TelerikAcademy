// 1. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z}
//    in the Euclidian 3D space. Implement the ToString() to enable
//    printing a 3D point.
// 2. Add a private static read-only field to hold the start of the
//    coordinate system – the point O{0, 0, 0}. Add a static property
//    to return the point O.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Points3D
{
    public struct Point3D : IComparable
    {
        // Static field to store center of the coordinate system
        private static readonly Point3D pointZero;

        // Holds the points in 3D space
        private float x;
        private float y;
        private float z;

        // Static constructor to create a point zero
        static Point3D()
        {
            pointZero = new Point3D();
        }

        // Stores the points in 3D space
        public Point3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Public property to return center of the coordinate system
        public static Point3D PointZero { get { return pointZero; } }

        // Public propertes to Get and Set values in the point
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float Z
        {
            get { return z; }
            set { z = value; }
        }

        public override string ToString()
        {
            // Return the point display
            return string.Format("Point[x = {0}, y = {1}, z = {2}]", x, y, z);
        }

        public int CompareTo(object point)
        {
            float dist1 = Points3DCalculations.DistanceCalculations.CalcDistance(Point3D.PointZero, this);
            float dist2 = Points3DCalculations.DistanceCalculations.CalcDistance(Point3D.PointZero, (Point3D)point);

            if (dist1 < dist2)
            {
                return -1;
            }

            if (dist1 > dist2)
            {
                return 1;
            }

            return 0;
        }
    }
}