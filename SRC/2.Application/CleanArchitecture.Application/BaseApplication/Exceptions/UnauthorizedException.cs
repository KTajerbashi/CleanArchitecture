namespace CleanArchitecture.Application.BaseApplication.Exceptions;
public class UnauthorizedException : Exception
{
    public UnauthorizedException(string message) : base(message)
    {
    }
}
