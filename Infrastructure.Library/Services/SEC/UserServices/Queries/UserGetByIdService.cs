using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.SEC.UserRepositories.Models.Views;
using Application.Library.Repositories.SEC.UserRepositories.Queries;
using AutoMapper;
using Infrastructure.Library.DatabaseContextApplication.EF;

namespace Infrastructure.Library.Services.SEC.UserServices.Queries
{
    public class UserGetByIdService : IUserGetByIdRepository
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public UserGetByIdService(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<Result<UserView>> Execute(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
