using Microsoft.Extensions.Primitives;

namespace Design.Pattern.Library.Flyweight.Pattern
{
    public abstract class Flyweight
    {
        public abstract void Operation(string extrisicState);
    }

    public class ConcreteFlyweight : Flyweight
    {
        private string intrisicState;

        public ConcreteFlyweight(string intrisicState)
        {
            this.intrisicState = intrisicState;
        }

        public override void Operation(string extrisicState)
        {
            Console.WriteLine(@$"
ConcreteFlyweight.Operation 
Inner State : {intrisicState}
Outer State : {extrisicState}
");
        }
    }

    /// <summary>
    /// مسوول مدیریت آبجکت های عنصر ما است
    /// </summary>
    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> Flyweights 
            = new Dictionary<string, Flyweight>();


        public Flyweight GetFlyweight(string key)
        {
            Flyweight flyweight = null;
            if (Flyweights.TryGetValue(key,out flyweight))
            {

            }
            else
            {
                Flyweights.Add(key, new ConcreteFlyweight(key));
            }
            return Flyweights[key];
        }
    }

    public class UnSharedFlyweight : Flyweight
    {

        private IEnumerable<Flyweight> Flyweights;

        public UnSharedFlyweight(IEnumerable<Flyweight> flyweights)
        {
            Flyweights = flyweights;
        }

        public override void Operation(string extrisicState)
        {
            Console.WriteLine("UnSharedFlyweight == extrisicState");
            foreach (var item in Flyweights)
            {
                item.Operation(extrisicState);
            }
        }
    }
}
