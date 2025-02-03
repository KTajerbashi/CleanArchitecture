namespace CleanArchitecture.Core.Domain.Library.Exceptions;

public class DomainException : Exception
{
    public DomainException(string msg) : base(msg) { }
    public DomainException(string msg, Exception exception) : base(msg, exception) { }
    public DomainException(Exception exception) : base(exception.Message, exception) { }
}
