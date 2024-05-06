namespace Design.Pattern.Library.Adapter.Notifications
{
    public class TelegramService : ISendMessage
    {
        public void Send()
        {
            Console.WriteLine("TelegramService.Send()");
        }
    }
}
