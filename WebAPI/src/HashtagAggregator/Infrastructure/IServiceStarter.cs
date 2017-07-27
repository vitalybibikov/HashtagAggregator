using System;

namespace HashtagAggregator.Infrastructure
{
    public interface IServiceStarter
    {
        void Start();

        void Stop();
    }
}