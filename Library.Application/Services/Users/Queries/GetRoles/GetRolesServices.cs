using Library.Common;

namespace Library.Application
{
    public class GetRolesServices //: IGetRolesServices
    {
        private readonly IDataBaseContext _context;
        public GetRolesServices(IDataBaseContext context)
        {
            _context = context;
        }
        //public ResultDto<List<RolesDto>> Execute()
        //{
        //    var roles = _context.Roles.ToList().Select(p => new RolesDto
        //    {
        //        Id = p.Id,
        //        Name = p.Name,
        //    }).ToList();
        //    return new ResultDto<List<RolesDto>>()
        //    {
        //        Data = roles,
        //        IsSuccess = true,
        //        Message = ""
        //    };
        //}
    }
}
