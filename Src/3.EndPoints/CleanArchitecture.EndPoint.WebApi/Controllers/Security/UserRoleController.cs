using CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUserRole.GetAll;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Security;

public class UserRoleController : AuthorizationController
{

    //[HttpPost]
    //public async Task<IActionResult> Create(UserRoleCreateRequest request) => await RequestAsync<UserRoleCreateRequest, UserRoleCreateResponse>(request);

    //[HttpPut]
    //public async Task<IActionResult> Update(UserRoleUpdateRequest Request) => await RequestAsync<UserRoleUpdateRequest, UserRoleUpdateResponse>(Request);

    //[HttpDelete("{entityId}")]
    //public async Task<IActionResult> Delete(Guid entityId) => await RequestAsync<UserRoleDeleteRequest, UserRoleDeleteResponse>(new UserRoleDeleteRequest(entityId));

    [HttpGet]
    public async Task<IActionResult> Get() => await RequestAsync<UserRoleGetRequest, List<UserRoleGetResponse>>(new UserRoleGetRequest());

    //[HttpGet("{entityId}")]
    //public async Task<IActionResult> Get(Guid entityId) => await RequestAsync<UserRoleGetByIdRequest, UserRoleGetByIdResponse>(new UserRoleGetByIdRequest(entityId));

    [HttpGet("GetByCurrentUser")]
    public async Task<IActionResult> GetByCurrentUser() => await RequestAsync<UserRoleGetRequest, List<UserRoleGetResponse>>(new());
}