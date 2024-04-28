namespace Design.Pattern.Library.Decorator
{
    /// <summary>
    /// We Can Add Feature to base Class with out base source codes and we can create many ConcreteDecorator Class for our feature
    /// This is our ConcreteDecorator class to add feature
    /// with this class we add feature
    /// </summary>
    public class ConcreteDecorator : Decorator
    {
        public ConcreteDecorator(Component component) : base(component)
        {
        }

        /// <summary>
        /// Operation in ConcreteDecorator : Decorator
        /// </summary>
        public override void Operation()
        {
            NewFeatureBeforeLogging();
            base.Operation();
            NewFeatureAfterLogging();
        }
        /// <summary>
        /// Before Call Base 
        /// </summary>
        public void NewFeatureBeforeLogging()
        {
            Console.WriteLine("New Feature Before Logging() from ConcreteDecorator");
        }
        /// <summary>
        /// After Call Base
        /// </summary>
        public void NewFeatureAfterLogging()
        {
            Console.WriteLine("New Feature After Logging() from ConcreteDecorator");
        }
    }


}
