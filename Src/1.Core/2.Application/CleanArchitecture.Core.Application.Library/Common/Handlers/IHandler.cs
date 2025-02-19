using CleanArchitecture.Core.Application.Library.Common.Models.Requests;

namespace CleanArchitecture.Core.Application.Library.Common.Handlers;

public interface IHandler<TRequest> : IRequestHandler<TRequest>
    where TRequest : RequestModel
{
}
public abstract class Handler<TRequest> : IHandler<TRequest>
    where TRequest : RequestModel
{
    protected readonly ProviderServices ProviderServices;
    protected Handler(ProviderServices providerServices)
    {
        ProviderServices = providerServices;
    }
    public abstract Task Handle(TRequest request, CancellationToken cancellationToken);

}

public interface IHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : RequestModel<TResponse>
{
}
public abstract class Handler<TRequest, TResponse> : IHandler<TRequest, TResponse>
    where TRequest : RequestModel<TResponse>
{
    protected readonly ProviderServices ProviderServices;
    protected Handler(ProviderServices providerServices)
    {
        ProviderServices = providerServices;
    }
    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

}
