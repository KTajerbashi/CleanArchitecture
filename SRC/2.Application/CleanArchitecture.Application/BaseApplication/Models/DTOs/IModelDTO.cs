namespace CleanArchitecture.Application.BaseApplication.Models.DTOs;

public interface IModelDTO<TId>
{
    TId Id { get; set; }
}
public class ModelDTO<TId> : IModelDTO<TId>
{
    public TId Id { get; set; }
}
public class ModelDTO : ModelDTO<long>
{

}