namespace CleanArchitecture.Application.BaseApplication.Models.Views;


public interface IModelView
{
   
}
public class ModelView<TId> : IModelView
{
    public TId Id { get; set; }
}
public class ModelView : ModelView<long>
{

}
public class DropDownView<TId> : ModelView<TId>
{
    public string Title { get; set; }
    public bool IsSelected { get; set; }
}

public class DataListView<TData> : IModelView
{
    public IEnumerable<TData> Data { get; set; }
    public int Count { get; set; }
    public int Page { get; set; }
    public int Skip { get; set; }
    public int Row { get; set; }
}