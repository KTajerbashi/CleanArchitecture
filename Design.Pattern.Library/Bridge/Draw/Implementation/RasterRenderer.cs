namespace Design.Pattern.Library.Bridge.Draw.Implementation
{
    /// <summary>
    /// Concrete Implementation
    /// </summary>
    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius} using raster graphics.");
        }
        public void RenderSquare(float side)
        {
            Console.WriteLine($"Drawing a square of side {side} using raster graphics.");
        }
    }
}
