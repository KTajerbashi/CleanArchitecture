//using CleanArchitecture.WebApi.Extensions.Identity.Services;
//using CleanArchitecture.WebApi.Extensions.Settings;
//using CleanArchitecture.WebApi.UserManagement.Repositories;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Text;

//namespace CleanArchitecture.WebApi.Middlewares.JwtHandler;

//public class JwtMiddleware
//{
//    private readonly RequestDelegate _next;
//    private readonly AppSettings _appSettings;

//    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
//    {
//        _next = next;
//        _appSettings = appSettings.Value;
//    }

//    public async Task Invoke(HttpContext context, IIdentityService identityService)
//    {
//        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

//        if (token != null)
//            await attachUserToContext(context, identityService, token);

//        await _next(context);
//    }

//    private async Task attachUserToContext(HttpContext context, IIdentityService identityService, string token)
//    {
//        try
//        {
//            var myToken = TokenGenerator.GenerateToken();
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
//            tokenHandler.ValidateToken(token, new TokenValidationParameters
//            {
//                ValidateIssuerSigningKey = true,
//                IssuerSigningKey = new SymmetricSecurityKey(key),
//                ValidateIssuer = false,
//                ValidateAudience = false,
//                // set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
//                ClockSkew = TimeSpan.Zero
//            }, out SecurityToken validatedToken);

//            var jwtToken = (JwtSecurityToken)validatedToken;
//            var userId = long.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

//            //Attach user to context on successful JWT validation
//            context.Items["User"] = await identityService.UserManager.FindByIdAsync($"{userId}");
//        }
//        catch
//        {
//            //Do nothing if JWT validation fails
//            // user is not attached to context so the request won't have access to secure routes
//        }
//    }
//}
