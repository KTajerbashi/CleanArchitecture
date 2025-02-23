using CleanArchitecture.Core.Application.Library.Providers;
using CleanArchitecture.EndPoint.WebApi.Common.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.EndPoint.WebApi.Controllers;

//public class CacheController : AuthController
public class CacheController : BaseController
{
    private readonly ProviderServices _providerServices;

    public CacheController(IMediator mediator, ProviderServices providerServices) : base(mediator)
    {
        _providerServices = providerServices;
    }

    [HttpPut("{key}/{value}")]
    public IActionResult Add(string key, string value)
    {
        Dictionary<string,string> keys = new Dictionary<string,string>();
        _providerServices.CacheAdapter.Add(key, value, DateTime.Now.AddMinutes(5), DateTime.Now.TimeOfDay);
        return Ok($"Successfully Added => {key} : {_providerServices.CacheAdapter.Get<string>(key)}");
    }

    [HttpDelete("{key}")]
    public IActionResult Remove(string key)
    {
        _providerServices.CacheAdapter.RemoveCache(key);

        return Ok($"Successfully Removed => {key} : {_providerServices.CacheAdapter.Get<string>(key)}");
    }

    [HttpGet("{key}")]
    public IActionResult Get(string key)
    {
        var cacheValue = _providerServices.CacheAdapter.Get<string>(key);
        return Ok($"Successfully Get => {key} : {cacheValue}");
    }

}
