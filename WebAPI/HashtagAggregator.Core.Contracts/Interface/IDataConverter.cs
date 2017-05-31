
namespace HashtagAggregator.Core.Contracts.Interface
{
    public interface IDataConverter<T>
    {
        T Convert(T item);
    }
}
