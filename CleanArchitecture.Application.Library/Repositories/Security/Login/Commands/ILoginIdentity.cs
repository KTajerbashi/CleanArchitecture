using CleanArchitecture.Application.Library.Repositories.Security.Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Library.Repositories.Security.Login.Commands
{
    public interface ILoginIdentity
    {
        void Execute(LoginModel model);
    }
}
