namespace Design.Pattern.Library.Decorator.Pattern
{
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
}
