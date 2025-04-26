using CleanArchitecture.Core.Domain.Library.Exceptions;

namespace CleanArchitecture.Core.Application.Library.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string message) : base(message)
    {

    }
    public NotFoundException(Exception exception) : base(exception.Message, exception)
    {

    }
}
