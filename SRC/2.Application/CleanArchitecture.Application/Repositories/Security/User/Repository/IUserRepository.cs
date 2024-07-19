using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;
using CleanArchitecture.Application.Repositories.Security.User.Model.Views;
using CleanArchitecture.Domain.Security.Entities;

namespace CleanArchitecture.Application.Repositories.Security.User.Repository;

public interface IUserRepository : IBaseRepository<UserEntity,UserDTO,UserView, long>
{
}
