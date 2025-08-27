using CleanArchitecture.Core.Application.Common.Models.Requests;
using CleanArchitecture.Core.Application.Providers;

namespace CleanArchitecture.Core.Application.Common.Handlers;

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
