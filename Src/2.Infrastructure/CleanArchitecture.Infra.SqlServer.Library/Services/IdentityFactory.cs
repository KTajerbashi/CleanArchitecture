using CleanArchitecture.Core.Application.Library.Interfaces;
using CleanArchitecture.Core.Application.Library.Providers.UserManagement;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infra.SqlServer.Library.Services;
public class IdentityFactory : IIdentityFactory
{
    private readonly IPasswordHasher<AppUserEntity> _passwordHasher;
    public IdentityFactory(IPasswordHasher<AppUserEntity> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }
    public string ConcurrencyStamp(string password)
    {
        return Guid.NewGuid().ToString();
    }

    public string PasswordHash(AppUserEntity entity, string password)
    {
        return _passwordHasher.HashPassword(entity, password); ;
    }

    public string SecurityStamp(string password)
    {
        byte[] bytes = new byte[20];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }

    public bool VerifyHashedPassword(AppUserEntity entity, string passwordHash, string password)
    {
        PasswordVerificationResult verificationResult = _passwordHasher.VerifyHashedPassword(entity, passwordHash, password);
        return verificationResult == PasswordVerificationResult.Success;
    }
}
