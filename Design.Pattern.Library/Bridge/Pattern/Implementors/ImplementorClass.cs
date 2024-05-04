namespace Design.Pattern.Library.Bridge.Pattern.Implementors
{
    public abstract class ImplementorClass
    {
        public abstract void Implementation();
    }

    public class ConcreteImplementor : ImplementorClass
    {
        public override void Implementation()
        {
            Console.WriteLine($"Implementation() in ConcreteImplementor Extend ImplementorClass");
        }
    }
}
