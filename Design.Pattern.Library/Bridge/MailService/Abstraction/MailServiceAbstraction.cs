using Design.Pattern.Library.Bridge.MailService.Implementors;
using Design.Pattern.Library.Bridge.MailService.Models;

namespace Design.Pattern.Library.Bridge.MailService.Abstraction
{
    public abstract class MailServiceAbstraction
    {
        private readonly IMailServiceImplementor mailServiceImplementor;

        protected MailServiceAbstraction()
        {
            this.mailServiceImplementor = Implementation.GetImplementor();
        }

        public virtual void SendEmail(EmailDTO email)
        {
            mailServiceImplementor.SendMail(email.Reciever,email.Message);
        }
    }
    //// انتزاع را از پیاده سازی جدا میکنیم
    public class RefinedMailService : MailServiceAbstraction
    {
      
    }
}
