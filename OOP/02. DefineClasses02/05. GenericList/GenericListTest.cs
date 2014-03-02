using _01.Points3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GenericList
{
    public static class GenericListTest
    {
        static void Main(string[] args)
        {
            // Create new GenericList
            GenericList<Point3D> points = new GenericList<Point3D>(2);

            // Test adding of elements and auto double size of list
            PrintLengthCapacity(points, "----- Test adding of elements and auto double size of list -----");
            points.Add(new Point3D(1, 2, 3));
            PrintLengthCapacity(points);
            points.Add(new Point3D());
            PrintLengthCapacity(points);
            points.Add(new Point3D(2, 4, 8));
            PrintLengthCapacity(points);
            points.Add(new Point3D(3, 5, 6));
            PrintLengthCapacity(points);

            // Access elements by index
            Console.WriteLine("----- Access elements by index -----");
            Console.WriteLine("Element[1] = {0}", points[1]);
            points[1] = new Point3D(33, 33, 33);
            PrintLengthCapacity(points, "Add new value of element[1] = " + points[1]);

            // Test find of index of given element
            Console.WriteLine("Index of element[2] = {0}", points.IndexOf(points[2]));

            // Test remove element by index
            points.RemoveAt(2);
            PrintLengthCapacity(points, "Test remove element by index");

            // Test insert element by index
            points.Insert(2, new Point3D(44, 44, 44));
            PrintLengthCapacity(points, "Test insert element by index");
            points.Insert(3, new Point3D(666, 666, 666));
            PrintLengthCapacity(points, "Test insert element by index");

            // Test Clear of list
            points.Clear();
            PrintLengthCapacity(points, "----- Test list clearing -----");
        }

        // Print Length, Capacity and current GenericList
        private static void PrintLengthCapacity(GenericList<Point3D> points, string strIn = null)
        {
            if (strIn != null)
            {
                Console.WriteLine(strIn);
            }

            Console.WriteLine("Length = {0}", points.Length);
            Console.WriteLine("Capacity = {0}", points.Capacity);
            Console.WriteLine("List: {0}", points);
            Console.WriteLine();
            Console.WriteLine("Min element: {0}", points.Min());
            Console.WriteLine("Max element: {0}", points.Max());
            Console.WriteLine();
        }
    }
}