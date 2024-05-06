using Design.Pattern.Library.Adapter.Notifications.ExternalServices;

namespace Design.Pattern.Library.Adapter.Notifications.Pattern
{
    public class GmailAdapter : ISendMessage
    {
        ExternalService ExternalService = new ExternalService();

        public void Send()
        {
            ExternalService.Execute();
        }
    }
}
