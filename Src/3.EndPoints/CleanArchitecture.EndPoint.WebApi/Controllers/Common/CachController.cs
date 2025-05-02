namespace CleanArchitecture.EndPoint.WebApi.Controllers.Common;

public class CacheRequest
{
    public string Key { get; set; }
    public string Value { get; set; }
}
public class CachController :BaseController
{
    [HttpPost("Set")]
    public IActionResult Set(CacheRequest request)
    {
        ProviderServices.CacheAdapter.Add(request.Key, request.Value, DateTime.Now.AddMinutes(1), TimeSpan.FromMinutes(1));
        return Ok(request);
    }

    [HttpGet("{Key}")]
    public IActionResult Get(string Key)
    {
        return Ok(ProviderServices.CacheAdapter.Get<string>(Key));
    }
}
