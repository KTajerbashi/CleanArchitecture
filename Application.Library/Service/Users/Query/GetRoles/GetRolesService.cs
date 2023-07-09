using Application.Library.Interfaces;
using Common.Library;

namespace Application.Library.Service
{
    public partial class GetRolesService : IGetRolesService
    {
        private readonly IDatabaseContext _context;
        public GetRolesService(IDatabaseContext context)
        {
            _context = context;
        }

        ResultDTO<List<RolesDto>> IGetRolesService.Execute()
        {
            var roles = _context.Roles.ToList().Select(r => new RolesDto
            {
                ID = r.ID,
                Title = r.Title,
            }).ToList();

            var item = new ResultDTO<List<RolesDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = ""
            };
            return item ;
        }
    }
}
