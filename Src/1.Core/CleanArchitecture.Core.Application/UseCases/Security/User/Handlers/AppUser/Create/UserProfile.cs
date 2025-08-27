using CleanArchitecture.Core.Domain.UseCases.Security;
using CleanArchitecture.Core.Domain.UseCases.Security.Parameters;

namespace CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUser.Create;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateRequest, AppUserCreateParameters>().ReverseMap();
        CreateMap<UserCreateRequest, AppUserEntity>().ReverseMap();
        // Add other mappings as needed
    }
}
