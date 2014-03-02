using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Points3D.Points3DPath
{
    public static class Points3DPathStorage
    {
        // Read PointsPath from file
        public static PointsPath ReadPoints3DPath(string fileStr)
        {
            List<Point3D> path = new List<Point3D>();

            try
            {
                using (StreamReader sr = new StreamReader(fileStr))
                {
                    while (sr.Peek() >= 0)
                    {
                        // Read float numbers from file and create a Point3D in the path
                        string[] floatStr = new string[3];
                        floatStr = sr.ReadLine().Split(' ');
                        path.Add(new Point3D(float.Parse(floatStr[0]), float.Parse(floatStr[1]), float.Parse(floatStr[2])));
                    }

                    // Return loaded path
                    return new PointsPath(path);
                }
            }
            catch (Exception)
            {
                // Throw exception if input date is wrong
                throw new ArgumentException("Wrong input!");
            }
        }

        // Write PointsPath to file
        public static void WritePoints3DPath(PointsPath path, string fileStr)
        {
            try
            {
                // Open file for rewrite and store the path point by point
                using (FileStream fs = new FileStream(fileStr, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var point in path.Path)
                    {
                        sw.WriteLine("{0} {1} {2}", point.X, point.Y, point.Z);
                    }
                }
            }
            catch (Exception)
            {
                // Throw exception if have a problem to write data
                throw new IOException("File writing problem!");
            }
        }
    }
}