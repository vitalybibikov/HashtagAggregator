using System;

namespace HashtagAggregator.Core.Models
{
    public class MessageConverter
    {
        public string ConvertBody(string body, int length)
        {
            if (!String.IsNullOrWhiteSpace(body) && body.Length > length)
            {
                body = body.Substring(0, length);
            }
            return body;
        }
    }
}
