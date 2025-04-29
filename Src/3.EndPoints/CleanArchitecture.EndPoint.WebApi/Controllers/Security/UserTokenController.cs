using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Handlers.AppUserToken.GetAll;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Security;

public class UserTokenController : AuthorizationController
{

    //[HttpPost]
    //public async Task<IActionResult> Create(UserTokenCreateRequest request) => await RequestAsync<UserTokenCreateRequest, UserTokenCreateResponse>(request);

    //[HttpPut]
    //public async Task<IActionResult> Update(UserTokenUpdateRequest Request) => await RequestAsync<UserTokenUpdateRequest, UserTokenUpdateResponse>(Request);

    //[HttpDelete("{entityId}")]
    //public async Task<IActionResult> Delete(Guid entityId) => await RequestAsync<UserTokenDeleteRequest, UserTokenDeleteResponse>(new UserTokenDeleteRequest(entityId));

    [HttpGet]
    public async Task<IActionResult> Get() => await RequestAsync<UserTokenGetRequest, List<UserTokenGetResponse>>(new UserTokenGetRequest());

    //[HttpGet("{entityId}")]
    //public async Task<IActionResult> Get(Guid entityId) => await RequestAsync<UserTokenGetByIdRequest, UserTokenGetByIdResponse>(new UserTokenGetByIdRequest(entityId));

    [HttpGet("GetByCurrentUser")]
    public async Task<IActionResult> GetByCurrentUser() => await RequestAsync<UserTokenGetRequest, List<UserTokenGetResponse>>(new());
}