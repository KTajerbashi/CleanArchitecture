using CleanArchitecture.Application.BaseApplication.Exceptions;
using System.Net;

namespace CleanArchitecture.WebApi.Middlewares.ExceptionHandler;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception switch
        {
            NotFoundException => (int)HttpStatusCode.NotFound,
            UnauthorizedException => (int)HttpStatusCode.Unauthorized,
            BadRequestException => (int)HttpStatusCode.BadRequest,
            ForbiddenException => (int)HttpStatusCode.Forbidden,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var message = exception switch
        {
            NotFoundException => exception.Message,
            UnauthorizedException => exception.Message,
            BadRequestException => exception.Message,
            ForbiddenException => exception.Message,
            _ => $"Internal Server Error from the custom middleware.\n{exception.Message}"
        };

        return context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        }.ToString());
    }
}
