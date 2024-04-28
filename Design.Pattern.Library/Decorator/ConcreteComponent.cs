using Design.Pattern.Library.Decorator.SendEmail;

namespace Design.Pattern.Library.Decorator
{
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
