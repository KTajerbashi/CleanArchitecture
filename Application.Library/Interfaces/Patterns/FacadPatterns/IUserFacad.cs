using Application.Library.Service;

namespace Application.Library.Interfaces.Patterns
{
    public interface IUserFacad
    {
        RegisterUserService RegisterUserService { get; }
        EditUserService EditUserService { get; }
        RemoveUserService RemoveUserService { get; }
        IUserLoginServices UserLoginServices { get; }
        UserSatusChangeService UserSatusChangeService { get; }
        IGetUsersService GetUsersService { get; }
        IGetRolesService GetRolesService { get; }
    }
}
