using CleanArchitecture.Core.Application.Library.BaseCoreApplication.PatternMediartR.Command;
using CleanArchitecture.Core.Application.Library.Providers;

namespace CleanArchitecture.Core.Application.Library.UseCases.Identity.User.Add;

public class AddUserHandler : CommandHandler<AddUserRequest, AddUserResponse>
{
    public AddUserHandler(ProviderServices provider) : base(provider)
    {
    }

    public override Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
