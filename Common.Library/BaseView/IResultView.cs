namespace Common.Library
{
    public interface IResultView
    {
    }
    public class ResultView<T> : IResultView
    {
        public T ID { get; set; }
    }
    public class ResultView : ResultView<long>
    {
    }
}
