using System;

namespace HashtagAggregator.Tests.TestHelpers
{
    public static class DateTimeExtensions
    {
        public static int ToUnixTime(this DateTime offset)
        {
            var utc = offset.ToUniversalTime();
            return (int)utc.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
