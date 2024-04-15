using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.SEC.UserRepositories.Models.Views;
using Application.Library.Repositories.SEC.UserRepositories.Queries;
using AutoMapper;
using CleanArchitecture.Infrastructure.Library.DatabaseContextApplication.EF;

namespace CleanArchitecture.Infrastructure.Library.Services.SEC.UserServices.Queries
{
    public class UserGetAllService : IUserGetAllRepository
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public UserGetAllService(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<Result<List<UserView>>> Execute()
        {
            throw new NotImplementedException();
        }
    }
}
