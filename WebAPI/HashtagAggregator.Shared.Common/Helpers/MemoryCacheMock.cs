using System;
using HashtagAggregator.Shared.Contracts.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace HashtagAggregator.Shared.Common.Helpers
{
    /// <summary>
    /// Mock for MemoryCache. Currently it's very hard to mock MemoryCache.Set  method.
    /// </summary>
    public class MemoryCacheMock : IMemoryCacheWrapper
    {
        private readonly IMemoryCache cache;

        public MemoryCacheMock(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public bool TryGetValue(object key, out object value)
        {
            return cache.TryGetValue(key, out value);
        }

        public virtual T Set<T>(object key, T type, TimeSpan expiration)
        {
            return cache.Set(key, type, expiration);
        }

        public ICacheEntry CreateEntry(object key)
        {
            return cache.CreateEntry(key);
        }

        public void Remove(object key)
        {
            cache.Remove(key);
        }

        public void Dispose()
        {
            cache?.Dispose();
        }

    }
}
