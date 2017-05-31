namespace HashtagAggregator.Data.Contracts.Interface.JobObjects
{
    /// <summary>
    /// Marker interface
    /// </summary>
    public interface IVkBackgroundJob<in T> : IBackgroundJob<T>
    {
    }
}
