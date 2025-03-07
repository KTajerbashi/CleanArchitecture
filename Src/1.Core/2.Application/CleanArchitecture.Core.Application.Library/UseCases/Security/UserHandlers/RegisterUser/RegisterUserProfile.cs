﻿using CleanArchitecture.Core.Domain.Library.Entities.Security;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.UserHandlers.RegisterUser;

public class RegisterUserProfile : Profile
{
    public RegisterUserProfile()
    {
        CreateMap<RegisterUserRequest, AppUserEntity>().ReverseMap();
    }
}
