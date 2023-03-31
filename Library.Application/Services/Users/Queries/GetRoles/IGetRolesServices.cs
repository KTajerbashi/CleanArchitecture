using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface IGetRolesServices
    {
        ResultDto<List<RolesDto>> Execute();
    }
}
