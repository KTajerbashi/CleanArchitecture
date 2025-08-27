using CleanArchitecture.Core.Domain.Common;

namespace CleanArchitecture.Core.Domain.UseCases.Security;

[Table("UserLogins", Schema = "Security"), Description("User Login Entity Model")]
public class AppUserLoginEntity : BaseAuditableEntity
{
    public string LoginProvider { get; private set; } = default!;
    public string ProviderKey { get; private set; } = default!;
    public string? ProviderDisplayName { get; private set; }
    public long UserId { get; private set; } = default!;

}


