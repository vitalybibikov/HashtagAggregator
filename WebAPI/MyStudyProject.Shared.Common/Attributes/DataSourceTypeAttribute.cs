using System;

using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Shared.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class DataSourceTypeAttribute : Attribute
    {
        public DataSourceTypeAttribute(SocialMediaType mediaType)
        {
            this.MediaType = mediaType;
        }

        public SocialMediaType MediaType { get; }

    }
}
