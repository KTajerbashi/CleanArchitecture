using CleanArchitecture.Core.Application.Library.Providers;
using MediatR;

namespace CleanArchitecture.Core.Application.Library.BaseCoreApplication.PatternMediartR.Command;

#region Command

public interface ICommandHandler<TRequest> : IRequestHandler<TRequest>
    where TRequest : IRequest
{
}
public abstract class CommandHandler<TRequest> : ICommandHandler<TRequest>
    where TRequest : IRequest
{
    private readonly ProviderServices Provider;

    protected CommandHandler(ProviderServices provider)
    {
        Provider = provider;
    }

    public abstract Task Handle(TRequest request, CancellationToken cancellationToken);
}

public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
}
public abstract class CommandHandler<TRequest, TResponse> : ICommandHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ProviderServices Provider;

    protected CommandHandler(ProviderServices provider)
    {
        Provider = provider;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

#endregion



