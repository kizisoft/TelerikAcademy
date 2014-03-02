namespace _01.Shapes
{
    using System;

    public class Circle : Shape
    {
        public Circle(int r)
        {
            this.width = r;
            this.height = r;
        }

        // Calculate the surface of Circle
        public override double CalculateSurface()
        {
            return Math.PI * this.width * this.width;
        }
    }
}