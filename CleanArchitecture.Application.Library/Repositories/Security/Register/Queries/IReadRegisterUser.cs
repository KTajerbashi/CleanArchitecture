using CleanArchitecture.Application.Library.Repositories.Security.Register.Model;

namespace CleanArchitecture.Application.Library.Repositories.Security.Register.Queries
{
    public interface IReadRegisterUser
    {
        RegisterUserModel Execute();
    }
}
