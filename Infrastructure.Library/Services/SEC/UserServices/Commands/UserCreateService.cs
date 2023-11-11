﻿using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.SEC.UserRepositories.Commands;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;
using AutoMapper;
using Infrastructure.Library.DatabaseContextApplication.EF;

namespace Infrastructure.Library.Services.SEC.UserServices.Commands
{
    public class UserCreateService : IUserCreateRepository
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public UserCreateService(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Result<UserDTO> Execute(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
