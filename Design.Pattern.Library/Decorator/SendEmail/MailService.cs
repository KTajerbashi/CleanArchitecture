namespace Design.Pattern.Library.Decorator.SendEmail
{
    public abstract class MailService
    {
        public abstract void Execute();
    }
    public class ConcreteMailService : MailService
    {
        public override void Execute()
        {
        }
    }
    public class MailServiceDecorate : MailService
    {
        private readonly MailService _service;
        public MailServiceDecorate(MailService service)
        {
            _service = service;
        }
        public override void Execute()
        {
            _service.Execute();
        }
    }
}
