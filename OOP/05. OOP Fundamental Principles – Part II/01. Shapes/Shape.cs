namespace _01.Shapes
{
    public abstract class Shape
    {
        // Protected fields
        protected int width;
        protected int height;

        // Define a virtuale method to calculate surface
        public abstract double CalculateSurface();
    }
}