namespace CleanArchitecture.Core.Domain.Library.UseCases.Security;

[Table("UserClaims", Schema = "Security"), Description("User Claim Entity Model")]
public class AppUserClaimEntity : BaseAuditableEntity
{
    public long UserId { get; private set; } = default!;
    public string? ClaimType { get; private set; }
    public string? ClaimValue { get; private set; }
}


