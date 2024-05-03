namespace Design.Pattern.Library.Facade.SubSystem.DrawContainer
{
    public class DrawService : IDrawRepository
    {
        public void Execute()
        {
            Console.WriteLine("Execute in DrawService");
        }
    }
}
