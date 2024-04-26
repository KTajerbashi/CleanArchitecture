using CleanArchitecture.Domain.TestLibrary.Security.User;

namespace CleanArchitecture.Application.TestLibrary.Services.Security
{
    public interface IUserServiceContainer
    {
        UserModelTest Get(int id);
    }
    //public class UserServiceContainer : IUserServiceContainer
    //{
    //    public UserModelTest Get(int id)
    //    {
    //        var list = new List<UserModelTest>();
    //        list.Add(new UserModelTest() { Id = 1, Name = "Ali1", Email = "Ali@mail.com", Password = "@Ali123", Age = 10 });
    //        list.Add(new UserModelTest() { Id = 2, Name = "Ali2", Email = "Ali@mail.com", Password = "@Ali123", Age = 25 });
    //        list.Add(new UserModelTest() { Id = 3, Name = "Ali3", Email = "Ali@mail.com", Password = "@Ali123", Age = 15 });
    //        list.Add(new UserModelTest() { Id = 4, Name = "Ali4", Email = "Ali@mail.com", Password = "@Ali123", Age = 5 });
    //        list.Add(new UserModelTest() { Id = 5, Name = "Ali5", Email = "Ali@mail.com", Password = "@Ali123", Age = 30 });
    //        list.Add(new UserModelTest() { Id = 6, Name = "Ali6", Email = "Ali@mail.com", Password = "@Ali123", Age = 35 });
    //        list.Add(new UserModelTest() { Id = 7, Name = "Ali7", Email = "Ali@mail.com", Password = "@Ali123", Age = 40 });
    //        list.Add(new UserModelTest() { Id = 8, Name = "Ali8", Email = "Ali@mail.com", Password = "@Ali123", Age = 45 });
    //        list.Add(new UserModelTest() { Id = 9, Name = "Ali9", Email = "Ali@mail.com", Password = "@Ali123", Age = 19 });

    //        return list.Where(x => x.Id == id).Single();
    //    }
        
    //}
    public class DiscountService
    {
        private readonly IUserServiceContainer userService;

        public DiscountService(IUserServiceContainer userService)
        {
            this.userService = userService;
        }

        public int Execute(int id)
        {
            var model = userService.Get(id);
            if (model.Age > 30)
            {
                return 1000;
            }
            else if (model.Age > 20)
            {
                return 1000;
            }
            else if (model.Age > 10)
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }
    }
}
