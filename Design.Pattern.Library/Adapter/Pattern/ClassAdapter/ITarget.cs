namespace Design.Pattern.Library.Adapter.Pattern.ClassAdapter
{
    /// <summary>
    /// Class Adapter 
    /// </summary>
    public interface ITarget
    {
        void Operation();
    }

    public class Adaptee
    {
        public void SpecificOperation()
        {
            Console.WriteLine($"Adaptee.SpecificOperation()");
        }
    }
    public class Adapter : Adaptee, ITarget
    {
        public void Operation()
        {
            base.SpecificOperation();
        }
    }
}
