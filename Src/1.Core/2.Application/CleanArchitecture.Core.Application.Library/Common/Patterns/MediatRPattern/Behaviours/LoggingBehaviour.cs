using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Core.Application.Library.Common.Patterns.MediatRPattern.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;
    public LoggingBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = "Tajer";
        var userName = "Tajerbashi";
        _logger.LogInformation("CleanArchitecture Request: {Name} {@UserId} {@UserName} {@Request}", requestName, userId, userName, request);
        return await next();
    }
}
