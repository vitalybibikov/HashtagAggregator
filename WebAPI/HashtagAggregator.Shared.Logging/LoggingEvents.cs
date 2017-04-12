namespace HashtagAggregator.Shared.Logging
{
    public sealed class LoggingEvents
    {
        //Common
        public const int GENERATE_ITEMS = 1000;
        public const int LIST_ITEMS = 1001;
        public const int GET_ITEM = 1002;
        public const int INSERT_ITEM = 1003;
        public const int UPDATE_ITEM = 1004;
        public const int DELETE_ITEM = 1005;


        public const int REQUEST_FILTER_DENIED = 1100;

        public const int FAILED_PUBLISH_TWITTER_MESSAGE = 4100;
        public const int FAILED_PUBLISH_VK_MESSAGE = 4200;

        //Common Error
        public const int EXCEPTION_EXECUTE_COMMAND = 5000;
        public const int EXCEPTION_EXECUTE_QUERY = 5001;

        //Twitter
        public const int EXCEPTION_GET_TWITTER_MESSAGE = 5100;
        public const int EXCEPTION_SAVE_TWITTER_MESSAGE = 5104;

        //VK
        public const int EXCEPTION_GET_VK_MESSAGE = 5200;
        public const int EXCEPTION_SAVE_VK_MESSAGE = 5204;
    }
}
