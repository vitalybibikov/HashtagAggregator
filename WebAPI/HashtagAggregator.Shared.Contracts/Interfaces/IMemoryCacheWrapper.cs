using System;
using Microsoft.Extensions.Caching.Memory;

namespace HashtagAggregator.Shared.Contracts.Interfaces
{
    public interface IMemoryCacheWrapper : IMemoryCache
    {
        T Set<T>(object key, T type, TimeSpan expiration);
    }
}
