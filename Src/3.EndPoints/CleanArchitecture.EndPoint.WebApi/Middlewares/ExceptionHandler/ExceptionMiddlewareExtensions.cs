using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Mime;
using static System.Net.Mime.MediaTypeNames;

namespace CleanArchitecture.EndPoint.WebApi.Middlewares.ExceptionHandler;

public class ApiError
{
    public string Message { get; set; }
    public string Controller { get; set; }
    public string Method { get; set; }
    public string Error { get; set; }
    public string InnerError { get; set; }
    public string StackTrace { get; set; }
}

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(async context =>
            {
                var logger = context.RequestServices.GetRequiredService<ILogger<ApiError>>();
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature?.Error;

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                if (exception != null)
                {
                    var routeData = context.GetRouteData();

                    var error = new ApiError
                    {
                        Message = exception.Message,
                        Controller = routeData?.Values["controller"]?.ToString() ?? context.Request.Path,
                        Method = routeData?.Values["action"]?.ToString() ?? context.Request.Method,
                        Error = exception.GetType().Name,
                        StackTrace = exception.StackTrace
                    };

                    // Build inner exception chain
                    var innerException = exception.InnerException;
                    if (innerException != null)
                    {
                        var innerErrors = new List<string>();
                        while (innerException != null)
                        {
                            innerErrors.Add($"{innerException.GetType().Name}: {innerException.Message}");
                            innerException = innerException.InnerException;
                        }
                        error.InnerError = string.Join(" => ", innerErrors);
                    }

                    // Log the error
                    logger.LogError(exception,
                        "Unhandled exception occurred in {Controller}.{Method}: {ErrorMessage}",
                        error.Controller,
                        error.Method,
                        error.Message);

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
                }
                else
                {
                    logger.LogError("An unknown error occurred");
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiError
                    {
                        Message = "An unknown error occurred"
                    }));
                }
            });
        });
    }
}