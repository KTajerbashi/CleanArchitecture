namespace Design.Pattern.Library.Decorator.Pattern
{
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
}
