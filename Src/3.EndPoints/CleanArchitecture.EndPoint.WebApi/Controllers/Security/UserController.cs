using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.Create;
using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.Delete;
using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.GetAll;
using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.GetById;
using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.Update;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Security;

public class UserController : AuthorizationController
{

    [HttpPost]
    public async Task<IActionResult> Create(UserCreateRequest request) => await RequestAsync<UserCreateRequest, UserCreateResponse>(request);

    [HttpPut]
    public async Task<IActionResult> Update(UserUpdateRequest Request) => await RequestAsync<UserUpdateRequest, UserUpdateResponse>(Request);

    [HttpDelete("{entityId}")]
    public async Task<IActionResult> Delete(Guid entityId) => await RequestAsync<UserDeleteRequest, UserDeleteResponse>(new UserDeleteRequest(entityId));

    [HttpGet]
    public async Task<IActionResult> Get() => await RequestAsync<UserGetAllRequest, List<UserGetAllResponse>>(new UserGetAllRequest());

    [HttpGet("{entityId}")]
    public async Task<IActionResult> Get(Guid entityId) => await RequestAsync<UserGetByIdRequest, UserGetByIdResponse>(new UserGetByIdRequest(entityId));
}

