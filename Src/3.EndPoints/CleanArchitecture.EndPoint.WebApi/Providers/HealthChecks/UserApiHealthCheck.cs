using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CleanArchitecture.EndPoint.WebApi.Providers.HealthChecks;

public class UserApiHealthCheck : IHealthCheck
{
    private readonly IHttpClientFactory _httpClientFactory;

    public UserApiHealthCheck(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        //  Type 1
        //var client = _httpClientFactory.CreateClient();
        //client.BaseAddress = new Uri("https://localhost:2235");

        //  Type 2
        var client = _httpClientFactory.CreateClient("UserApi");
        var response = await client.GetAsync("/api/Authenticate/CurrentUser");
        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "your-token");

        return response.IsSuccessStatusCode
            ? HealthCheckResult.Healthy()
            : HealthCheckResult.Degraded($"API returned: {response.StatusCode}");
    }
}
