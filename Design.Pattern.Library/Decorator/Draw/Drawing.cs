namespace Design.Pattern.Library.Decorator.Draw
{
    public abstract class Drawing
    {
        public abstract void Draw();
    }
    public class DrawPaint : Drawing
    {
        public override void Draw()
        {
            Console.WriteLine($"Draw() => in DrawPaint extend Drawing");
        }
    }

    public class DecoratorDrawing: Drawing
    {
        private readonly Drawing drawing;

        public DecoratorDrawing(Drawing drawing)
        {
            this.drawing = drawing;
        }

        public override void Draw()
        {
            drawing.Draw();
        }
    }

    public class ConcreteDecoratorDrawing : DecoratorDrawing
    {
        public ConcreteDecoratorDrawing(Drawing drawing) : base(drawing)
        {
            ConcreteDecoratorDrawing  dc = drawing as ConcreteDecoratorDrawing;
            if (dc == null)
            {

            }
        }

        public override void Draw()
        {
            base.Draw();
            DrawCircle();
        }

        public void DrawCircle()
        {
            Console.WriteLine("DrawCircle() => ConcreteDecoratorDrawing:DecoratorDrawing");
        }
    }

}
