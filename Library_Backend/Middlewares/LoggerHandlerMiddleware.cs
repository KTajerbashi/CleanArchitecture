using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EndPoint_WebApi.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggerHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggerHandlerMiddleware(RequestDelegate next)
        {
            Console.WriteLine("LoggerHandlerMiddleware CTOR1");
            _next = next;
            Console.WriteLine("LoggerHandlerMiddleware CTOR2");
        }

        public Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("LoggerHandlerMiddleware Invoke Before");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoggerHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggerHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerHandlerMiddleware>();
        }
    }
}
