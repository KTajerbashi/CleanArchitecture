using Application.Library.Patterns.Facad.SEC;
using Application.Library.Repositories.SEC.UserRepositories.Commands;
using Application.Library.Repositories.SEC.UserRepositories.Queries;
using AutoMapper;
using Infrastructure.Library.DatabaseContextApplication.EF;
using Infrastructure.Library.Services.SEC.UserServices.Commands;
using Infrastructure.Library.Services.SEC.UserServices.Queries;

namespace Infrastructure.Library.Patterns.Facad.SEC
{
    public class UserFacad : IUserFacad
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public UserFacad(DBContextApplication context,IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }


        private UserCreateService _userCreateService;
        public IUserCreateRepository UserCreateRepository
        {
            get
            {
                return _userCreateService = _userCreateService ?? new UserCreateService(_context, _mapper);
            }
        }

        private UserUpdateService _userUpdateService;
        public IUserUpdateRepository UserUpdateRepository
        {
            get
            {
                return _userUpdateService = _userUpdateService ?? new UserUpdateService(_context, _mapper);
            }
        }
        private UserDeleteService _userDeleteService;
        public IUserDeleteRepository UserDeleteRepository
        {
            get
            {
                return _userDeleteService = _userDeleteService ?? new UserDeleteService(_context, _mapper);
            }
        }

        private UserGetAllService _userGetAllService;
        public IUserGetAllRepository UserGetAllRepository
        {
            get
            {
                return _userGetAllService = _userGetAllService ?? new UserGetAllService(_context, _mapper);
            }
        }
        public UserGetByIdService _userGetByIdService;
        public IUserGetByIdRepository UserGetByIdRepository
        {
            get
            {
                return _userGetByIdService = _userGetByIdService ?? new UserGetByIdService(_context, _mapper);
            }
        }
        public UserGetSearchService _userGetSearchService;
        public IUserGetSearchRepository UserGetSearchRepository
        {
            get
            {
                return _userGetSearchService = _userGetSearchService ?? new UserGetSearchService(_context, _mapper);
            }
        }
    }
}
