using Common.Library;
using static Application.Library.Service.GetRolesService;

namespace Application.Library.Service
{
    public interface IGetRolesService
    {
        ResultDto<List<RolesDto>> Execute();
    }
}
