using CleanArchitecture.Core.Domain.Library.UseCases.Security;
using CleanArchitecture.Core.Domain.Library.UseCases.Security.Parameters;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.AppUser.Create;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateRequest, AppUserCreateParameters>().ReverseMap();
        CreateMap<UserCreateRequest, AppUserEntity>().ReverseMap();
        // Add other mappings as needed
    }
}
