using Design.Pattern.Library.Bridge.Draw.Implementation;

namespace Design.Pattern.Library.Bridge.Draw.Abstraction
{
    public class Circle : Shape
    {
        private float radius;
        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }
        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }
    }


}
