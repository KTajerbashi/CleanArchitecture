using CleanArchitecture.Domain.TestLibrary.Security.User;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using Xunit.Abstractions;
namespace CleanArchitecture.Application.TestLibrary.Services.Security
{
    public class UserServiceTest
    {
        private readonly ITestOutputHelper output;
        public UserServiceTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void When_User_Age_Usual_Discount()
        {
            Mock<IUserServiceContainer> mockService = new Mock<IUserServiceContainer>();
            mockService.Setup(c => c.Get(1)).Returns(new UserModelTest
            {
                Id = 1,
                Name = "Name 1",
                Email = "Email@mail.com",
                Password = "@Mail#1200",
                Age = 25
            });
            //  Arrange
            var service = new DiscountService(mockService.Object);
            //  Act
            var result = service.Execute(1);
            output.WriteLine($"Name : {mockService.Name}");
            output.WriteLine($"Result : {result}");
            //  Assert
            Assert.Equal(1000, result);
        }
        [Fact]
        public void UpdateUser()
        {
            //  Arrange
            //  Act
            //  Assert
        }
        [Fact]
        public void DeleteUser()
        {
            //  Arrange
            //  Act
            //  Assert
        }
        [Fact]
        public void ReadUser()
        {
            //  Arrange
            //  Act
            //  Assert
        }

    }
}
