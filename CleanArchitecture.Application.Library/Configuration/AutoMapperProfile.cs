using AutoMapper;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Models.Views;
using CleanArchitecture.Domain.Library.Entities.Security;

namespace CleanArchitecture.Application.Library.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Securit
            CreateMap<User, UserDTO>();
            CreateMap<User, UserView>();
            #endregion
        }
    }
}
