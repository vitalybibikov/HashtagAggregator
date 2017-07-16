using System;


namespace HashTagAggregator.Tests.DataHelpers.Common
{
    public class IdGenerator
    {
        public static string GetNetworkId()
        {
            var random = new Random();
            return random.Next(1, Int32.MaxValue).ToString();
        }

        public static int GetInt32RandomId()
        {
            var random = new Random();
            return random.Next(1, Int32.MaxValue);
        }
    }
}
