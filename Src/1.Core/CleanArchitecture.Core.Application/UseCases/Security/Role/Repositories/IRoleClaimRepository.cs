using CleanArchitecture.Core.Application.Common.Repository;
using CleanArchitecture.Core.Domain.UseCases.Security;

namespace CleanArchitecture.Core.Application.UseCases.Security.Role.Repositories;

public interface IRoleClaimRepository : IRepository<AppRoleClaimEntity, int>
{
}
