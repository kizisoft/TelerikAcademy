// 4. Create a class Path to hold a sequence of points in the 3D space.
//    Create a static class PathStorage with static methods to save and
//    load paths from a text file. Use a file format of your choice.

using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Points3D.Points3DPath
{
    public class PointsPath
    {
        // Store a list of points for path
        private List<Point3D> path;

        // Create a new path
        public PointsPath()
        {
            this.path = new List<Point3D>();
        }

        // Store a new path
        public PointsPath(List<Point3D> path)
        {
            this.path = path;
        }

        // Returns the path of points
        public List<Point3D> Path { get { return path; } }

        // Returns the path of points represented as a string
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < path.Count; i++)
            {
                sb.Append(this.path[i]);

                if (i < path.Count - 1)
                {
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }

        // Add a point to the path
        public void AddPoint(Point3D point)
        {
            this.path.Add(point);
        }
    }
}