using Design.Pattern.Library.Tools;

namespace Design.Pattern.Library.Decorator
{
    public class DecoratorContainer
    {
        public DecoratorContainer(DesignConsole design)
        {
            design.NewLine();
            ConcreteComponent component = new();
            component.Operation();
            design.NewLine();
            ConcreteDecorator concreteLogging = new (component);
            concreteLogging.Operation();
            design.NewLine();
            ConcreteDecoratorGetData decoratorGetData = new (component);
            decoratorGetData.Operation();
            design.NewLine();
        }
    }

}
