using Design.Pattern.Library.Proxy.Sample.MainSource;
using Design.Pattern.Library.Proxy.Sample.RealSubject;

namespace Design.Pattern.Library.Proxy.Sample
{
    public class BankServerProxy : IBankRepository
    {
        private BankService bankService;

        public void Deposit()
        {

            bankService.Deposit();
        }

        public void Harvest()
        {
            GetRealSubject().Harvest();
        }

        internal BankService GetRealSubject()
        {
            if (bankService == null)
            {
                bankService = new BankService();
            }
            return bankService;
        }
    }
}
