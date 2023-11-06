using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;
using Application.Library.Repositories.SEC.UserRepositories.Models.Views;
using Domain.Library.Entities.SEC;
using Persistance.Library.ProfileMapper;

namespace Infrastructure.Library.DatabaseServices.SqlServer
{
    public class MapperProfile : AutoMapperConfiguration
    {
        public MapperProfile(IAutoMapperConfiguration mapper) : base(mapper)
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserView>().ReverseMap();
        }
    }
}
