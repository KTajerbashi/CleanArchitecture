namespace Application.Library.Service
{
    public interface IGetUsersService
    {
        ResultGetUsersDTO Execute(RequestGetUserDTO request);
    }
}
