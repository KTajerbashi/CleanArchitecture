using Design.Pattern.Library.Bridge.Implementors;

namespace Design.Pattern.Library.Bridge.Abstractions
{
    public abstract class AbstractionClass
    {
        private  ImplementorClass implementorClass;

        protected AbstractionClass()
        {
            this.implementorClass = new ConcreteImplementor();
        }

        public virtual void Function()
        {
            implementorClass.Implementation();
        }
    }
    public class RefinedAbstractionClass : AbstractionClass
    {

    }
}
