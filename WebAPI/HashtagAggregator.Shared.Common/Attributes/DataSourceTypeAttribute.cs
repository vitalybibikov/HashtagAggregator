using System;

using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Shared.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class DataSourceTypeAttribute : Attribute
    {
        public DataSourceTypeAttribute(SocialMediaType mediaType)
        {
            MediaType = mediaType;
        }

        public SocialMediaType MediaType { get; }
    }
}
