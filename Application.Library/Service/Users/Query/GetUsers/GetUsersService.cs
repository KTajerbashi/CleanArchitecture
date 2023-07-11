using Application.Library.Interfaces;
using Common.Library;

namespace Application.Library.Service
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDatabaseContext _context;
        public GetUsersService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultGetUsersDTO Execute(RequestGetUserDTO request)
        {
            var users = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(c => (!c.IsDeleted && c.IsActive && c.Name.Contains(request.SearchKey)) && (c.Family.Contains(request.SearchKey) || c.Username.Contains(request.SearchKey)));
            }

            int rowsCount = 0;
            var paging = users.ToPaged(request.Page,20,out rowsCount);

            var userResult = paging.Select(p => new GetUsersDto
            {
                ID = p.ID,
                Name = p.Name,
                Family = p.Family,
                Email = p.Email,
                Username = p.Username,
                Password = p.Password,
                IsActive = p.IsActive
            }).ToList();

            return new ResultGetUsersDTO
            {
                Rows = rowsCount,
                Users = userResult
            };
        }
    }
}
