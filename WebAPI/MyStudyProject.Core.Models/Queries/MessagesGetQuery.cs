using MyStudyProject.Core.Contracts.Interface.Cqrs;

namespace MyStudyProject.Core.Models.Queries
{
    public class MessagesGetQuery : IQuery
    {
        public string HashTag { get; set; }
    }
}
