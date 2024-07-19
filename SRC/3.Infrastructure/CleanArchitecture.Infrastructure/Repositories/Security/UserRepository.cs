using CleanArchitecture.Application.BaseApplication.Exceptions;
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
    public override Task InsertAsync(UserDTO entity)
    {
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
