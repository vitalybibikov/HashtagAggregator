using System;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Shared.Common.Attributes;
using MyStudyProject.Shared.Common.Settings;
using MyStudyProject.Shared.Contracts.Enums;
using MyStudyProject.Shared.Contracts.Interfaces;

namespace MyStudyProject.Core.Cqrs.RequestFilter
{
    public class RequestQueryFilter : IRequestFilter
    {
        private IMemoryCacheWrapper memoryCache;
        private readonly IOptions<InternetUpdateSettings> updateSettings;

        public RequestQueryFilter(IMemoryCacheWrapper memoryCache, IOptions<InternetUpdateSettings> updateSettings)
        {
            this.memoryCache = memoryCache;
            this.updateSettings = updateSettings;
        }

        public Task<bool> IsRequestAllowed(object handler)
        {
            bool isAllowed = true;
            DataSourceTypeAttribute attribute =
                handler?.GetType().GetTypeInfo().GetCustomAttribute<DataSourceTypeAttribute>();
            if (attribute != null)
            {
                if (IsObjectInCache(attribute))
                {
                    isAllowed = false;
                }
                else
                {
                    AddToCache(attribute);
                }
            }
            TaskCompletionSource<bool> src = new TaskCompletionSource<bool>();
            src.SetResult(isAllowed);
            return src.Task;
        }

        private void AddToCache(DataSourceTypeAttribute attribute)
        {
            var expiration = TimeSpan.FromMilliseconds(updateSettings.Value.UpdatePeriod);
            memoryCache.Set(attribute.MediaType, attribute.MediaType, expiration);
        }

        private bool IsObjectInCache(DataSourceTypeAttribute attribute)
        {
            SocialMediaType media;
            return memoryCache.TryGetValue(attribute.MediaType, out media);
        }
    }
}
