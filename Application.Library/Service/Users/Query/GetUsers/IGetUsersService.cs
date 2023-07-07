namespace Application.Library.Service
{
    public interface IGetUsersService
    {
        ResultGetUsersDto Execute(RequestGetUsers request);
    }
}
