using CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUserLogin.GetAll;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Security;

public class UserLoginController : AuthorizationController
{

    //[HttpPost]
    //public async Task<IActionResult> Create(UserLoginCreateRequest request) => await RequestAsync<UserLoginCreateRequest, UserLoginCreateResponse>(request);

    //[HttpPut]
    //public async Task<IActionResult> Update(UserLoginUpdateRequest Request) => await RequestAsync<UserLoginUpdateRequest, UserLoginUpdateResponse>(Request);

    //[HttpDelete("{entityId}")]
    //public async Task<IActionResult> Delete(Guid entityId) => await RequestAsync<UserLoginDeleteRequest, UserLoginDeleteResponse>(new UserLoginDeleteRequest(entityId));

    [HttpGet]
    public async Task<IActionResult> Get() => await RequestAsync<UserLoginGetRequest, List<UserLoginGetResponse>>(new UserLoginGetRequest());

    //[HttpGet("{entityId}")]
    //public async Task<IActionResult> Get(Guid entityId) => await RequestAsync<UserLoginGetByIdRequest, UserLoginGetByIdResponse>(new UserLoginGetByIdRequest(entityId));

    [HttpGet("GetByCurrentUser")]
    public async Task<IActionResult> GetByCurrentUser() => await RequestAsync<UserLoginGetRequest, List<UserLoginGetResponse>>(new());
}