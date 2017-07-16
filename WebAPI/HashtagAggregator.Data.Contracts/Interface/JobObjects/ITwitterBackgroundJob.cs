namespace HashtagAggregator.Data.Contracts.Interface.JobObjects
{
    /// <summary>
    /// Marker interface
    /// </summary>
    public interface ITwitterBackgroundJob<in T> : IBackgroundJob<T>
    {
    }
}
