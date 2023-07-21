using Application.Library.Interfaces;
using Application.Library.Interfaces.Patterns;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Service
{
    public class UserFacad : IUserFacad
    {
        private readonly IDatabaseContext _context;
        public UserFacad(
            IDatabaseContext context
            )
        {
            _context = context;
        }

        private RegisterUserService _registerUserService;
        public RegisterUserService RegisterUserService
        {
            get
            {
                return _registerUserService = _registerUserService ?? new RegisterUserService(_context);
            }
        }

        private EditUserService _editUserService;
        public EditUserService EditUserService
        {
            get
            {
                return _editUserService = _editUserService ?? new EditUserService(_context);
            }
        }
        public RemoveUserService _removeUserService;
        public RemoveUserService RemoveUserService
        {
            get
            {
                return _removeUserService = _removeUserService ?? new RemoveUserService(_context);
            }
        }
        public IUserLoginServices _userLoginServices;
        public IUserLoginServices UserLoginServices
        {
            get
            {
                return _userLoginServices = _userLoginServices ?? new UserLoginServices(_context);
            }
        }
        public UserSatusChangeService _userSatusChangeService;
        public UserSatusChangeService UserSatusChangeService
        {
            get
            {
                return _userSatusChangeService = _userSatusChangeService ?? new UserSatusChangeService(_context);
            }
        }

        private IGetUsersService _getUsersService;
        public IGetUsersService GetUsersService
        {
            get
            {
                return _getUsersService ?? _getUsersService ?? new GetUsersService(_context);
            }
        }

        public IGetRolesService _getRolesService;
        public IGetRolesService GetRolesService
        {
            get
            {
                return _getRolesService = _getRolesService ?? new GetRolesService(_context);
            }
        }       
    }
}
