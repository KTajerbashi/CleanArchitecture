using CleanArchitecture.Application.BaseApplication.Exceptions;
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
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(CleanArchitectureDb context, IMapperAdapter mapperFacad, ILogger logger) : base(context, mapperFacad, logger)
    {
    }

    public override Task InsertAsync(UserDTO entity)
    {
        var result = MapperFacad.Map<UserDTO,UserEntity>(entity);
        throw new UnauthorizedException("وارد سامانه شوید");
    }
    public override Task UpdateAsync(UserDTO entity)
    {
        throw new NotFoundException("پیدا نشده است");
    }
    public override bool Delete(long id)
    {
        throw new BadRequestException("درخواست نادرست است");
    }
    public override Task<IEnumerable<UserView>> GetAsync()
    {
        throw new ForbiddenException("دسترسی ندارد");
    }
}
