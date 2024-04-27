using AutoMapper;
using CleanArchitecture.Domain.Library.Entities.Security;

namespace CleanArchitecture.Application.Library.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Securit
            //CreateMap<UserEntity, UserDTO>();
            //CreateMap<UserEntity, UserView>();
            #endregion
        }
    }
}
