using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Service
{
    public interface IGetUsersService
    {
        ResultGetUsersDto Execute(RequestGetUsers request);
    }
}
