namespace CleanArchitecture.Domain.TestLibrary.Security.User
{
    public class UserServiceContainer
    {
        private readonly IUserServiceContainer userServiceContainer;
        public UserServiceContainer(IUserServiceContainer userServiceContainer)
        {
            this.userServiceContainer = userServiceContainer;
        }

        public int Execute(int id)
        {
            var user = userServiceContainer.Get(id);
            switch (user.UserType)
            {
                case UserType.VIP:
                    {
                        return 1000;
                    }
                case UserType.Middle:
                    {
                        return 500;
                    }
                case UserType.Low:
                    {
                        return 100;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }
    }
}
