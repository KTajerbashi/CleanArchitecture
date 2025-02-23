namespace CleanArchitecture.EndPoint.WebApi.Middlewares.AuthorizedHandler;

public static class AuthorizedMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthorizedMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuthorizedMiddleware>();
    }
}