using MediatR;

namespace CleanArchitecture.Core.Application.Library.BaseCoreApplication.PatternMediartR.Command;

#region Command
public interface ICommand : IRequest { }
public abstract class Command : ICommand { }

public interface ICommand<TResponse> : IRequest<TResponse> { }
public abstract class Command<TResponse> : ICommand<TResponse> { }


#endregion



