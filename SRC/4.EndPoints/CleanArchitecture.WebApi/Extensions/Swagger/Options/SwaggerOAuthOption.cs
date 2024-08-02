namespace CleanArchitecture.WebApi.Extensions.Swagger.Options;

public class SwaggerOAuthOption
{
    public bool Enabled { get; set; } = false;
    public string AuthorizationUrl { get; set; } = string.Empty;
    public string TokenUrl { get; set; } = string.Empty;
    public Dictionary<string, string> Scopes { get; set; } = new();
}