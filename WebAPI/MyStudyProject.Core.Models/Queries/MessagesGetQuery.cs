using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;

namespace MyStudyProject.Core.Models.Queries
{
    public class MessagesGetQuery : IQuery
    {
        private const string HashTagSymbol = "#";
        private string hashTag;

        public string HashTag
        {
            get { return hashTag; }
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
