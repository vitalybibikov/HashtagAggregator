using System;
using System.Text;

namespace HashtagAggregator.IdentityServer.Infrastructure
{
    public class UniqueRequestParamsBuilder
    {
        public string GetOAuthNonce()
        {
            return Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
        }

        public string GetOAuthTimeStamp()
        {
            var timeStamp = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64(timeStamp.TotalSeconds).ToString();
        }
    }
}
