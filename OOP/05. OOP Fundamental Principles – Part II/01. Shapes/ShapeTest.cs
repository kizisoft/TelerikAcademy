namespace _01.Shapes
{
    public class ShapeTest
    {
        public static void Main(string[] args)
        {
            // Create shapes array
            Shape[] shapes = new Shape[] { new Circle(10), new Triangle(10, 10), new Rectangle(10, 10) };

            // Print surface of the shapes
            foreach (var shape in shapes)
            {
                System.Console.WriteLine("I'm {0}. My Surface = {1}!", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}