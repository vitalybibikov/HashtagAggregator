using System;
using System.Text;
using System.Text.Encodings.Web;

namespace HashtagAggregator.Core.Entities.VkEntities
{
    public abstract class VkQuery
    {
        protected VkQuery(string baseUrl, string version)
        {
            if (String.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentException(nameof(baseUrl));
            }

            if (String.IsNullOrEmpty(version))
            {
                throw new ArgumentException(nameof(version));
            }

            BaseUrl = baseUrl;
            Version = version;
        }
        public string BaseUrl { get;  }

        public string Version { get; }

        public virtual string Encode(string query)
        {
            UrlEncoder encoder = UrlEncoder.Default;
            return encoder.Encode(query);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(BaseUrl);
            builder.Append("?v=");
            builder.Append(Version);
            return builder.ToString();
        }
    }
}
