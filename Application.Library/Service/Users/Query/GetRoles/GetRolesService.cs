using Application.Library.Interfaces;

namespace Application.Library.Service
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDatabaseContext _context;
        public GetRolesService(IDatabaseContext context)
        {
            _context = context;
        }
        public List<ResultGetRolesDto> Execute()
        {
            _context.Roles.AsQueryable();
            var data = _context.Roles.Where(r => !r.IsDeleted && r.IsActive).ToList();

            var items = data.Select(c => new ResultGetRolesDto()
            {
                Id = c.Id,
                Title= c.Title,
            });

            return items.ToList();
        }
    }
}
