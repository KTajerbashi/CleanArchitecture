using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Commands;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Queries;

namespace CleanArchitecture.Application.Library.Patterns.Facad.SEC
{
    public interface IUserFacad
    {
        IUserCreateRepository UserCreateRepository { get; }
        IUserUpdateRepository UserUpdateRepository { get; }
        IUserDeleteRepository UserDeleteRepository { get; }
        IUserGetAllRepository UserGetAllRepository { get; }
        IUserGetByIdRepository UserGetByIdRepository { get; }
        IUserGetSearchRepository UserGetSearchRepository { get; }

    }

}
