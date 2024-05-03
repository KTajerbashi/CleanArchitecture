using Design.Pattern.Library.Proxy.MainSource;
using Design.Pattern.Library.Proxy.RealSubject;

namespace Design.Pattern.Library.Proxy.Pattern
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
