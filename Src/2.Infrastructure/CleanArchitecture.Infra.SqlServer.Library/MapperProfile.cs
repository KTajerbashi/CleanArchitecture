using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.AppUser.GetAll;

namespace CleanArchitecture.Infra.SqlServer.Library;


public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AppUserEntity, UserGetAllResponse>().ReverseMap();
        CreateMap<AppUserEntity, UserEntity>().ReverseMap();
        // Add other mappings as needed
    }
}
