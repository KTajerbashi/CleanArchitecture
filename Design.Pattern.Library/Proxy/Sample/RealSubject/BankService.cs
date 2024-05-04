using Design.Pattern.Library.Proxy.Sample.MainSource;

namespace Design.Pattern.Library.Proxy.Sample.RealSubject
{
    internal class BankService : IBankRepository
    {
        public void Deposit()
        {
            Console.WriteLine("Deposit Money From Cart");
        }

        public void Harvest()
        {
            Console.WriteLine("Harvest Money From Cart");
        }
    }
}
