namespace CleanArchitecture.Domain.TestLibrary.Security.User
{
    public class FizFuzzUser
    {
        [Fact]
        public void ReturnOne()
        {
            //  Arrange
            var fizzFuzz = new FizzFuzz();
            //  Act
            string result = fizzFuzz.Execute(1);
            //  Assert
            Assert.Equal("1", result);
        }
        [Fact]
        public void ReturnOneTwo()
        {
            //  Arrange
            var fizzFuzz = new FizzFuzz();
            //  Act
            string result = fizzFuzz.Execute(2);
            //  Assert
            Assert.Equal("1,2", result);
        }
    }
}
