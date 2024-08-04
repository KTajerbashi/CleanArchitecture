namespace CleanArchitecture.WebApi.Extensions.Providers.Swagger.Options;

public class SwaggerDocOption
{
    public string Version { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Contact Contact { get; set; }
    public License License { get; set; }
    public string Key { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;
}
public class Contact
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

}

public class License
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

}
