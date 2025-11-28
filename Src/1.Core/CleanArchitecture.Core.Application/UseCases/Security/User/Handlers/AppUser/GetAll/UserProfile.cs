using CleanArchitecture.Core.Domain.UseCases.Security;

namespace CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUser.GetAll;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<AppUserEntity, UserGetAllResponse>().ReverseMap();
        // Add other mappings as needed
    }
}
