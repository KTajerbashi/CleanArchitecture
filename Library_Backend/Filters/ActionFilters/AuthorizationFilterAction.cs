using Microsoft.AspNetCore.Mvc.Filters;

namespace EndPoint_WebApi.Filters.ActionFilters
{
    public class AuthorizationFilterAction : ActionFilterAttribute
    {
        public AuthorizationFilterAction()
        {
            
        }
        //  Before Action Run
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var contextData = context;
            var controller = contextData.Controller;
            base.OnActionExecuting(context);
        }

        //  After Action Run
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var contextData = context;
            var controller = contextData.Controller;
            base.OnActionExecuted(context);
        }
    }
}
