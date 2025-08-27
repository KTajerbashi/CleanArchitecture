using CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUser.GetAll;
using CleanArchitecture.Core.Domain.UseCases.Security;
using CleanArchitecture.Infra.SqlServer.Identity.Entities;

namespace CleanArchitecture.Infra.SqlServer;


public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AppUserEntity, UserGetAllResponse>().ReverseMap();
        CreateMap<AppUserEntity, UserEntity>().ReverseMap();
        // Add other mappings as needed
    }
}
