namespace CleanArchitecture.WebApi.Extensions.Identity.Options;

public class JWTAppSetting
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string ExpireTime { get; set; }
    public string Token { get; set; }
}
