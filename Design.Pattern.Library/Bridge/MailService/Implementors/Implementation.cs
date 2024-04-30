using System.Configuration;

namespace Design.Pattern.Library.Bridge.MailService.Implementors
{
    public static class Implementation
    {
        public static IMailServiceImplementor GetImplementor()
        {
            //if (service.ToLower().Contains("Gmail"))
            //{
            //    return new GmailService();
            //}
            //else if (service.ToLower().Contains("email"))
            //{
            //    return new YahooService();
            //}
            //return new SmsService();

            var configuration = ConfigurationManager.AppSettings;

            if (configuration["EmailImplementor"] == ("Gmail"))
            {
                return new GmailService();
            }
            else if (configuration["EmailImplementor"] == ("Yahoo"))
            {
                return new YahooService();
            }
            return new SmsService();
        }
    }
}
