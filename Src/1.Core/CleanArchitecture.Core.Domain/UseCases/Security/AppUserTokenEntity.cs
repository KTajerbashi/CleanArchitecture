using CleanArchitecture.Core.Domain.Common;

namespace CleanArchitecture.Core.Domain.UseCases.Security;

[Table("UserTokens", Schema = "Security"), Description("User Token Entity Model")]
public class AppUserTokenEntity : BaseAuditableEntity
{
    public long UserId { get; set; } = default!;
    public string LoginProvider { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Value { get; set; }
}


