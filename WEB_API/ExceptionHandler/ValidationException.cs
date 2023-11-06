namespace WEB_API.ExceptionHandler
{
    public class ValidationException:Exception
    {
        public ValidationException() { }
        public ValidationException(string name)
            : base(String.Format("Invalid Student Name: {0}", name))
        {
        }
    }
}
