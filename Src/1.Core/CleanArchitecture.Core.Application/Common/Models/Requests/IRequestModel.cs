namespace CleanArchitecture.Core.Application.Common.Models.Requests;

public interface IRequestModel : IRequest { }
public abstract class RequestModel : IRequestModel { }


public interface IRequestModel<TResponse> : IRequest<TResponse> { }
public abstract class RequestModel<TResponse> : IRequestModel<TResponse> { }
