using Design.Pattern.Library.Bridge.Draw.Implementation;

namespace Design.Pattern.Library.Bridge.Draw.Abstraction
{
    public class Square : Shape
    {
        private float side;
        public Square(IRenderer renderer, float side) : base(renderer)
        {
            this.side = side;
        }
        public override void Draw()
        {
            renderer.RenderSquare(side);
        }
    }


}
