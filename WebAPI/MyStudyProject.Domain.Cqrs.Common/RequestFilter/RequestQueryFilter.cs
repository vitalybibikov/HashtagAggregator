using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Shared.Common.Attributes;
using MyStudyProject.Shared.Common.Settings;
using MyStudyProject.Shared.Contracts.Enums;
using MyStudyProject.Shared.Contracts.Interfaces;
using MyStudyProject.Shared.Logging;

namespace MyStudyProject.Domain.Cqrs.Common.RequestFilter
{
    public class RequestQueryFilter : IRequestFilter
    {
        private IMemoryCacheWrapper memoryCache;
        private readonly IOptions<InternetUpdateSettings> updateSettings;
        private readonly ILogger<RequestQueryFilter> logger;

        public RequestQueryFilter(IMemoryCacheWrapper memoryCache, IOptions<InternetUpdateSettings> updateSettings, ILogger<RequestQueryFilter> logger)
        {
            this.memoryCache = memoryCache;
            this.updateSettings = updateSettings;
            this.logger = logger;
        }

        public Task<bool> IsRequestAllowed(object handler)
        {
            DataSourceTypeAttribute attribute =
                handler?.GetType().GetTypeInfo().GetCustomAttribute<DataSourceTypeAttribute>();
            TaskCompletionSource<bool> src = new TaskCompletionSource<bool>();
            var result = IsRequestAllowed(attribute);
            src.SetResult(result);
            LogRequestResult(result, handler);
            return src.Task;
        }

        private bool IsRequestAllowed(DataSourceTypeAttribute attribute)
        {
            bool isAllowed = true;
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
            return isAllowed;
        }

        private void LogRequestResult(bool result, object handler)
        {
            if (!result)
            {
                logger.LogError(
                    LoggingEvents.REQUEST_FILTER_DENIED,
                    "Failed to add handler {@handler}",
                    handler);
            }
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
