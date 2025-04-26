//using CleanArchitecture.Core.Application.Library.Common.Handlers;
//using CleanArchitecture.Core.Domain.Library.UseCases.Security;

//namespace CleanArchitecture.Core.Application.Library.UseCases.Security.UserHandlers.RegisterUser;

//public class RegisterUserHandler : Handler<RegisterUserRequest, RegisterUserResponse>
//{
//    private readonly IIdentityService _identityService;
//    public RegisterUserHandler(ProviderServices providerServices, IIdentityService identityService) : base(providerServices)
//    {
//        _identityService = identityService;
//    }

//    public override async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
//    {
//        try
//        {
//            AppUserEntity appUserEntity = ProviderServices.Mapper.Map<RegisterUserRequest,AppUserEntity>(request);
//            var result = await _identityService.RegisterAsync(appUserEntity,request.Password);
//            return new RegisterUserResponse(result);
//        }
//        catch
//        {

//            throw;
//        }
//    }
//}
