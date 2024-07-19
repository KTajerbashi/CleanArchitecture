namespace CleanArchitecture.Application.BaseApplication.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}
