namespace Design.Pattern.Library.Decorator.SendEmail
{
    public abstract class MailService
    {
        /// <summary>
        /// Send Email
        /// </summary>
        public abstract void Execute();
    }
    public class ConcreteMailService : MailService
    {
        public override void Execute()
        {
            Console.WriteLine("Execute() ConcreteMailService : MailService");
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
    public class MailServiceConcreteDecorate : MailServiceDecorate
    {
        public MailServiceConcreteDecorate(MailService service) : base(service)
        {
        }
        public override void Execute()
        {
            Feature();
            base.Execute();
        }
        /// <summary>
        /// Send Confirmation Sms
        /// </summary>
        public void Feature()
        {
            Console.WriteLine("MailServiceConcreteDecorate Feature");
        }
    }
}
