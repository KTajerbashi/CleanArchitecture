using CleanArchitecture.Application.Library.Repositories.Security.Login.Models;

namespace CleanArchitecture.Application.Library.Repositories.Security.Login.Queries
{
    public interface IReadLogin
    {
        LoginModel Execute(long id);
    }
}
