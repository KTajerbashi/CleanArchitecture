using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Service
{
    public interface IGetRolesService
    {
        List<ResultGetRolesDto> Execute();
    }
}
