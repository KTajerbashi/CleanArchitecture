namespace Application.Library.ModelBase
{
    public interface IBaseView
    {
    }
    public abstract class BaseView<T> : IBaseView
    {
        public T ID { get; set; }
        public Guid Guid { get; set; }
    }
    public abstract class BaseView : BaseView<long>
    {
        public string Key { get; set; }
    }
}
