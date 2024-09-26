using AutoMapper;
using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;
using CleanArchitecture.Application.Repositories.Security.User.Model.Views;
using CleanArchitecture.Domain.Security.Entities;

namespace CleanArchitecture.Infrastructure.Repositories.Security.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity, UserDTO>().ReverseMap();
        CreateMap<UserEntity, UserView>().ReverseMap();
    }
}
