namespace Design.Pattern.Library.Adapter.Pattern.ObjectAdapter
{
    /// <summary>
    ///     Object Adapter
    /// </summary>
    public abstract class Target
    {
        public abstract void Operation();
    }
    public class Adaptee
    {
        public void SpecificOperation()
        {
            Console.WriteLine("Adaptee.SpecificOperation");
        }
    }
    public class Adapter : Target
    {
        private readonly Adaptee adaptee;

        public Adapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public override void Operation()
        {
            adaptee.SpecificOperation();
        }
    }
}
