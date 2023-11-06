namespace Application.Library.ExceptionHandler
{
    public class BusinessException : Exception
    {
        public BusinessException() { }
        public BusinessException(string name)
            : base(String.Format("Invalid Student Name: {0}", name))
        {
        }
    }
}
