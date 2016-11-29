using MyStudyProject.Core.Contracts.Interface.Cqrs;

namespace MyStudyProject.Core.Models.Queries
{
    public class UserInfoQuery : IQuery
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string MediaType { get; set; }
    }
}
