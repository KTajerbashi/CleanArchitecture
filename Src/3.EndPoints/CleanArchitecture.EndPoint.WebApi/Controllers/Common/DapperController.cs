using CleanArchitecture.Core.Domain.Library.Common;
using System.Threading.Tasks;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Common;

public class DapperController : BaseController
{
    [HttpPost("ReadList")]
    public async Task<IActionResult> ReadList(DapperRequest request)
    {
        var resut = await ProviderServices.DataDapper.ReadListAsync<UserDTO>(request.Query,new {});
        return Ok(resut);
    }

    [HttpGet("{entityId}")]
    public async Task<IActionResult> Get(Guid entityId)
    {
        var resut1 = await ProviderServices.DataDapper.ReadAsync<UserDTO>("SELECT * FROM Security.Users WHERE EntityId = @EntityId",new {EntityId = entityId});
        var resut2 = await ProviderServices.DataDapper.ReadAsync<UserDTO>("SELECT * FROM Security.Users WHERE EntityId = @EntityId",new {EntityId = entityId});
        var resut3 = await ProviderServices.DataDapper.ReadAsync<UserDTO>("SELECT * FROM Security.Users WHERE EntityId = @EntityId",new {EntityId = entityId});
        var resut4 = await ProviderServices.DataDapper.ReadAsync<UserDTO>("SELECT * FROM Security.Users WHERE EntityId = @EntityId",new {EntityId = entityId});
        var resut5 = await ProviderServices.DataDapper.ReadAsync<UserDTO>("SELECT * FROM Security.Users WHERE EntityId = @EntityId",new {EntityId = entityId});
        var resut6 = await ProviderServices.DataDapper.ReadAsync<UserDTO>("SELECT * FROM Security.Users WHERE EntityId = @EntityId",new {EntityId = entityId});
        var resut7 = await ProviderServices.DataDapper.ReadAsync<UserDTO>("SELECT * FROM Security.Users WHERE EntityId = @EntityId",new {EntityId = entityId});
        var resut8 = await ProviderServices.DataDapper.ReadAsync<UserDTO>("SELECT * FROM Security.Users WHERE EntityId = @EntityId",new {EntityId = entityId});
        return Ok(resut1);
    }
}

public class DapperRequest
{
    public string Query { get; set; }
}

public class UserDTO
{
    public long Id { get; set; }
    public Guid EntityId { get; set; }
    public string DisplayName { get; set; }
}