using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.WebApi.Extensions.Identity.Extensions;

public static class JwtExtensions
{
    public static IServiceCollection AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {
        var secret = configuration["Jwt:Secret"];
        var key = Encoding.ASCII.GetBytes(secret);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });
        return services;
    }
}
