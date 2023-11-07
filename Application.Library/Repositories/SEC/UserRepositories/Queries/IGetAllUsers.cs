using Application.Library.ModelBase;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Repositories.SEC.UserRepositories.Queries
{
    public interface IGetAllUsers
    {
        Task<ResultPublicDTO<UserDTO>> Execute();
    }
}
