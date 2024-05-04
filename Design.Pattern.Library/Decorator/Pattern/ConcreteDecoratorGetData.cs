namespace Design.Pattern.Library.Decorator.Pattern
{
    public class ConcreteDecoratorGetData : Decorator
    {
        public ConcreteDecoratorGetData(Component component) : base(component)
        {
        }

        /// <summary>
        /// Operation in ConcreteDecorator : Decorator
        /// </summary>
        public override void Operation()
        {
            NewFeatureBeforeGetData();
            base.Operation();
            NewFeatureAfterGetData();
        }

        /// <summary>
        /// Before Call Base 
        /// </summary>
        public void NewFeatureBeforeGetData()
        {
            Console.WriteLine("New Feature Before GetData() from ConcreteDecorator");
        }

        /// <summary>
        /// After Call Base
        /// </summary>
        public void NewFeatureAfterGetData()
        {
            Console.WriteLine("New Feature After GetData() from ConcreteDecorator");
        }
    }
}
