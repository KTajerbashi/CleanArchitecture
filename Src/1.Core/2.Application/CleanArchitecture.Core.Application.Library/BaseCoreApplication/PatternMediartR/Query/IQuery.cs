using MediatR;

namespace CleanArchitecture.Core.Application.Library.BaseCoreApplication.PatternMediartR.Query;

#region Query
public interface IQuery<TResponse> : IRequest<TResponse> { }


public abstract class Query<TResponse> : IQuery<TResponse> { }
#endregion