using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;

namespace MyStudyProject.Core.Models.Queries
{
    public class MessagesGetQuery : IQuery
    {
        public string HashTag { get; set; }
    }
}
