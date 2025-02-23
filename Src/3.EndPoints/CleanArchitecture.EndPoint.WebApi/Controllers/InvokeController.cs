using CleanArchitecture.EndPoint.WebApi.Common.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CleanArchitecture.EndPoint.WebApi.Controllers;

public class InvokeController : BaseController
{
    public InvokeController(IMediator mediator) : base(mediator)
    {
    }

    public class ServiceInvoker
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

    [HttpGet]
    public IActionResult Invoke()
    {
        var @event = new ServiceInvoker();
        var onMethod = this.GetType().GetMethod("On", BindingFlags.Instance | BindingFlags.NonPublic, [@event.GetType()]);
        var ee = onMethod.Invoke(this, new[] { @event });

        return Ok(ee);
    }

    private int On(ServiceInvoker service)
    {
        return service.Sum(100,20);
    }

}