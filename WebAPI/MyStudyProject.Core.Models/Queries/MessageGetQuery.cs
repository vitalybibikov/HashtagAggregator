using MyStudyProject.Core.Contracts.Interface.Cqrs;

namespace MyStudyProject.Core.Models.Queries
{
    public class MessageGetQuery : IQuery
    {
        public long Id { get; set; }

        public string Body { get; set; }

        public string HashTag { get; set; }
    }
}
