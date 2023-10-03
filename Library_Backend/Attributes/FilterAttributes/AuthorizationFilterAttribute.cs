using Microsoft.AspNetCore.Mvc.Filters;

namespace EndPoint_WebApi.Attributes.FilterAttributes
{
    public class AuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var contextData = context;
            var req = context.HttpContext.Request;
            var res = context.HttpContext.Response;
            var resBody = context.HttpContext.Response.Body;
            var reqBody = context.HttpContext.Request.Body;
        }
    }
}
