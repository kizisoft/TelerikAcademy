namespace _01.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        // Calculate the surface of Rectangle
        public override double CalculateSurface()
        {
            return this.width * this.height;
        }
    }
}