﻿using CleanArchitecture.Application.Library.BaseModel.BaseDTO;
using CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Models.Views;

namespace CleanArchitecture.Application.Library.Repositories.SEC.UserRepositories.Queries
{
    public interface IUserGetSearchRepository
    {
        Task<Result<List<UserView>>> Execute(string search);
    }
}
