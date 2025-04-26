using CleanArchitecture.Core.Application.Library.Exceptions;
using CleanArchitecture.Core.Application.Library.Providers.Serializer.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CleanArchitecture.EndPoint.WebApi.Middlewares.ExceptionHandler
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IObjectSerializer _convertor;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IObjectSerializer convertor)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _convertor = convertor ?? throw new ArgumentNullException(nameof(convertor));
        }

        public async Task Invoke(HttpContext context)
        {
            context.TraceIdentifier = Activity.Current?.Id ?? context.TraceIdentifier;

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            LogException(exception);

            var statusCode = GetStatusCodeForException(exception);
            context.Response.StatusCode = statusCode;

            var errorDetails = CreateErrorDetails(context, exception, statusCode);
            await WriteErrorResponseAsync(context, errorDetails);
        }

        private void LogException(Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);
        }

        private int GetStatusCodeForException(Exception exception)
        {
            return exception switch
            {
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
        }

        private object CreateErrorDetails(HttpContext context, Exception exception, int statusCode)
        {
            return new
            {
                Status = statusCode,
                Title = statusCode == StatusCodes.Status401Unauthorized ? "Unauthorized" : "An error occurred while processing your request.",
                Message = exception.Message,
                TraceId = context.TraceIdentifier
            };
        }

        private async Task WriteErrorResponseAsync(HttpContext context, object errorDetails)
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(_convertor.Serialize(errorDetails));
        }
    }
}