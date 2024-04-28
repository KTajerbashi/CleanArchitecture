namespace Design.Pattern.Library.Decorator
{
    // tutorial : 1 => Create Component Class Or Exist Component Class
    // tutorial : 2 => Concrete Component Class : Component
    // tutorial : 3 => Decorator : Component
    // tutorial : 4 => Concrete Decorator : Decorator

    //  => 1
    public interface IComponent
    {
        void Operation();
    }
    public abstract class Component
    {
        /// <summary>
        /// Operation in Component
        /// </summary>
        public abstract void Operation();
    }

    //  => 2
    public class ConcreteComponent : Component, IComponent
    {
        /// <summary>
        /// Operation in ConcreteComponent:Component
        /// </summary>
        public override void Operation()
        {
            Console.WriteLine("Operation() From ConcreteComponent : Component ");
        }
    }

    //  => 3
    public abstract class Decorator : Component, IComponent
    {
        private readonly Component component;

        protected Decorator(Component component)
        {
            this.component = component;
        }
        /// <summary>
        /// Operation in Decorator : Component
        /// </summary>
        public override void Operation()
        {
            component.Operation();
        }
    }

    ///  => 4
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
