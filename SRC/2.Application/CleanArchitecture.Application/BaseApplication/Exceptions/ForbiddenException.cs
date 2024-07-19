namespace CleanArchitecture.Application.BaseApplication.Exceptions;

public class ForbiddenException : Exception
{
    public ForbiddenException(string message) : base(message)
    {
    }
}
