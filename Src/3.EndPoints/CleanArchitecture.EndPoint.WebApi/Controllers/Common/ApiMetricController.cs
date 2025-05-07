using System.Diagnostics;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Common;

public class ApiMetricController : BaseController
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;
    public ApiMetricController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _httpClient = _httpClientFactory.CreateClient(); ;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // Usage in your API clients
        var stopwatch = Stopwatch.StartNew();
        try
        {
            var response = await _httpClient.GetAsync("");
            return Ok(response);
        }
        catch
        {
            throw;
        }
    }
}
