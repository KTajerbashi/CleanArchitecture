using CleanArchitecture.Core.Domain.Exceptions;

namespace CleanArchitecture.Core.Application.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string message) : base(message)
    {

    }
    public NotFoundException(Exception exception) : base(exception.Message, exception)
    {

    }
}
