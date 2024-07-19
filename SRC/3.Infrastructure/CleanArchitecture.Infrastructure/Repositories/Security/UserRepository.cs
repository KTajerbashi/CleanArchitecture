using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;
using CleanArchitecture.Application.Repositories.Security.User.Model.Views;
using CleanArchitecture.Application.Repositories.Security.User.Repository;
using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseApplication;
using CleanArchitecture.Infrastructure.DatabaseContext;

namespace CleanArchitecture.Infrastructure.Repositories.Security;

public class UserRepository : BaseRepository<CleanArchitectureDb, UserEntity,UserDTO,UserView, long>, IUserRepository
{
    public UserRepository(CleanArchitectureDb context) : base(context)
    {
    }
}
