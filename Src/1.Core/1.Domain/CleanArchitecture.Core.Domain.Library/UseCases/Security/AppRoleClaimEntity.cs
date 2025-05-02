namespace CleanArchitecture.Core.Domain.Library.UseCases.Security;

[Table("RoleClaims", Schema = "Security"), Description("Role Claim Entity Model")]
public class AppRoleClaimEntity : BaseAuditableEntity<int>
{
    public long RoleId { get; private set; }
    public string? ClaimType { get; private set; }
    public string? ClaimValue { get; private set; }
}


