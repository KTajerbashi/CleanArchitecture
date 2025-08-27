using CleanArchitecture.Core.Application.Common.Repository;
using CleanArchitecture.Core.Domain.UseCases.Security;

namespace CleanArchitecture.Core.Application.UseCases.Security.User.Repositories;

public interface IUserRepository : IRepository<AppUserEntity, long>
{
    Task<AppUserEntity> GetByEmailAsync (string email);
    Task<AppUserEntity> GetByUsernameAsync(string username);
    void SetPassword(string password);
}
