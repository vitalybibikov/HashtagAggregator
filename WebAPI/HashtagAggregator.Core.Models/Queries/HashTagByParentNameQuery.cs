using HashtagAggregator.Core.Models.Interface.Cqrs.Query;

namespace HashtagAggregator.Core.Models.Queries
{
    public class HashTagByParentNameQuery : IQuery
    {
        private const string HashTagSymbol = "#";
        private string hashTag;

        public string HashTag
        {
            get
            {
                return hashTag;
            }
            set
            {
                if (!value.StartsWith(HashTagSymbol))
                {
                    value = "#" + value;
                }
                hashTag = value;
            }
        }
    }
}
