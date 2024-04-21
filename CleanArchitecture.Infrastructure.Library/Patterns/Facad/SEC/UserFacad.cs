using AutoMapper;
using CleanArchitecture.Application.Library.Patterns.Facad.SEC;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Commands;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Queries;
using CleanArchitecture.Persistence.Library.DataContext;

namespace CleanArchitecture.Infrastructure.Library.Patterns.Facad.SEC
{
    public class UserFacad : IUserFacad
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public UserFacad(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUserCreateRepository UserCreateRepository => throw new NotImplementedException();

        public IUserUpdateRepository UserUpdateRepository => throw new NotImplementedException();

        public IUserDeleteRepository UserDeleteRepository => throw new NotImplementedException();

        public IUserGetAllRepository UserGetAllRepository => throw new NotImplementedException();

        public IUserGetByIdRepository UserGetByIdRepository => throw new NotImplementedException();

        public IUserGetSearchRepository UserGetSearchRepository => throw new NotImplementedException();
    }
}
