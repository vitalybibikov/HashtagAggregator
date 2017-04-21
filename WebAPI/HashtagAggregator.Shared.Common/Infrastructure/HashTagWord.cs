using System;

namespace HashtagAggregator.Shared.Common.Infrastructure
{
    public class HashTagWord
    {
        private const string HashTagSymbol = "#";

        private readonly string originalTag;

        public string OriginalTag => originalTag;

        public string TagWithHash => ToString();

        public string NoHashTag => originalTag.StartsWith(HashTagSymbol) ? originalTag.Replace(HashTagSymbol, String.Empty) : originalTag;

        public HashTagWord(string originalTag)
        {
            this.originalTag = originalTag;
        }

        public override string ToString()
        {
            string hashTag = this.originalTag;
            if (!originalTag.StartsWith(HashTagSymbol))
            {
                hashTag = $"{HashTagSymbol}{originalTag}";
            }
            return hashTag;
        }
    }
}
