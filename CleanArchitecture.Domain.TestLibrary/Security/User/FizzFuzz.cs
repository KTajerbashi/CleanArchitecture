namespace CleanArchitecture.Domain.TestLibrary.Security.User
{
    public class FizzFuzz
    {
        public string Execute(int input)
        {
            switch (input)
            {
                case 1:
                    {
                        return "1";
                    }
                default:
                    {
                        return "1,2";
                    }
            }
        }
    }
}
