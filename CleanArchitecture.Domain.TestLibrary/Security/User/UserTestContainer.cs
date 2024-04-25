using Xunit.Abstractions;

namespace CleanArchitecture.Domain.TestLibrary.Security.User
{
    public class UserTestContainer
    {
        private readonly ITestOutputHelper _outputHelper;
        public UserTestContainer(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
        [Fact]
        public void TestConsole()
        {
            //  Arrange
            int a = 10;
            int b = 20;
            //  Act
            int c = a+b;

            Console.WriteLine(c);
            _outputHelper.WriteLine(c.ToString());
            //  Assert
            Assert.Equal(30, c);
        }

        public void When_UserTypeIs_Usual_Get1000()
        {
            //  Arrange
            UserServiceContainer service = new UserServiceContainer(null);
            //  Act
            var result = service.Execute(1);
            //  Assert
            Assert.Equal(1000,result);

        }

    }
}
