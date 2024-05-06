namespace Design.Pattern.Library.Adapter.Notifications
{
    public class WhatsAppService : ISendMessage
    {
        public void Send()
        {
            Console.WriteLine("WhatsAppService.Send()");
        }
    }
}
