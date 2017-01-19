using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace MyStudyProject.Shared.Contracts.Interfaces
{
    public interface IMemoryCacheWrapper : IMemoryCache
    {
        T Set<T>(object key, T type, TimeSpan expiration);
    }
}
