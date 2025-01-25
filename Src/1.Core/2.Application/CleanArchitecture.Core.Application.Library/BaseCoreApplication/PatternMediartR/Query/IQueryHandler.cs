using MediatR;

namespace CleanArchitecture.Core.Application.Library.BaseCoreApplication.PatternMediartR.Query;

public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IQuery<TResponse> { }

public abstract class QueryHandler<TRequest, TResponse> : IQueryHandler<TRequest, TResponse> where TRequest : IQuery<TResponse>
{
    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
