namespace _01.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(int a, int height)
        {
            this.width = a;
            this.height = height;
        }

        // Calculate the surface of Triangle
        public override double CalculateSurface()
        {
            return this.height * this.width / 2;
        }
    }
}