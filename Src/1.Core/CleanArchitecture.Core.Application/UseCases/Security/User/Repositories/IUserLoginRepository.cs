using CleanArchitecture.Core.Application.Common.Repository;
using CleanArchitecture.Core.Domain.UseCases.Security;

namespace CleanArchitecture.Core.Application.UseCases.Security.User.Repositories;

public interface IUserLoginRepository : IRepository<AppUserLoginEntity, long>
{
}
