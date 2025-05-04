using CleanArchitecture.Core.Application.Library.Common.Repository;
using CleanArchitecture.Core.Domain.Library.UseCases.Security;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;

public interface IUserRepository : IRepository<AppUserEntity, long>
{
    Task<AppUserEntity> GetByEmailAsync (string email);
    Task<AppUserEntity> GetByUsernameAsync(string username);
    void SetPassword(string password);
}
