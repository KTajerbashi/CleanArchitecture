namespace CleanArchitecture.Application.Library.ExceptionHandler
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {

        }
    }
}
