using CleanArchitecture.EndPoint.WebApi.Middlewares.ExceptionHandler;

namespace CleanArchitecture.EndPoint.WebApi.Middlewares.AuthorizedHandler;

public class AuthorizedMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorizedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
        {
            context.Response.ContentType = "application/json";
            var response = new
            {
                Status = 401,
                Title = "Unauthorized",
                Message = "You are not authorized to access this resource."
            };
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
    }
}
