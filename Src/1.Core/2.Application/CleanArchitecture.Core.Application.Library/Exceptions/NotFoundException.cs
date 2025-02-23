namespace CleanArchitecture.Core.Application.Library.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {

    }
    public NotFoundException(Exception exception) : base(exception.Message, exception)
    {

    }
}
