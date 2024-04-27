namespace CleanArchitecture.Application.Library.ExceptionHandler
{
    public class ValidationModelException : Exception
    {
        public ValidationModelException(string message) : base(message)
        {

        }
    }
}
