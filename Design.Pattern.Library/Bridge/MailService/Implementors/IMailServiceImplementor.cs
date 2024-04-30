using Design.Pattern.Library.Bridge.MailService.Models;

namespace Design.Pattern.Library.Bridge.MailService.Implementors
{
    public interface IMailServiceImplementor
    {
        void SendMail(string reciver, string body);

        List<EmailDTO> GetEmails();
    }
}
