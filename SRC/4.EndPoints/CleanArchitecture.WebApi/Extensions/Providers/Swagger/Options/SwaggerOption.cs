namespace CleanArchitecture.WebApi.Extensions.Providers.Swagger.Options;


public class SwaggerOption
{
    public bool Enabled { get; set; } = true;
    public SwaggerDocOption SwaggerDoc { get; set; } = new();
    public SwaggerOAuthOption OAuth { get; set; } = new();
}
