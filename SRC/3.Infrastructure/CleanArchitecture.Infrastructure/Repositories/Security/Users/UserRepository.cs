using CleanArchitecture.Application.Providers.MapperProvider.Abstract;
using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;
using CleanArchitecture.Application.Repositories.Security.User.Model.Views;
using CleanArchitecture.Application.Repositories.Security.User.Repository;
using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseApplication;
using CleanArchitecture.Infrastructure.DatabaseContext;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Repositories.Security.Users;
public class UserRepository : BaseRepository<CleanArchitectureDb, UserEntity, UserDTO, UserView, long>, IUserRepository
{
    public UserRepository(CleanArchitectureDb context, ILogger logger, IMapperAdapter mapperFacad) : base(context, logger, mapperFacad)
    {
    }
}
