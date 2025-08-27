using CleanArchitecture.Core.Domain.Exceptions;

namespace CleanArchitecture.Core.Application.Exceptions;

public class AppException : BaseException
{
    public AppException(string message) : base(message)
    {

    }
    public AppException(string message, Exception exception) : base(message, exception)
    {

    }

    public AppException(BaseException exception) : base(exception.Message, exception)
    {

    }
}
