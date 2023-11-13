using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.SEC.UserRepositories.Commands;
using AutoMapper;
using Infrastructure.Library.DatabaseContextApplication.EF;

namespace Infrastructure.Library.Services.SEC.UserServices.Commands
{
    public class UserDeleteService : IUserDeleteRepository
    {

        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public UserDeleteService(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<Result<bool>> Execute(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
