using MyStudyProject.Core.Contracts.Interface.Cqrs;

namespace MyStudyProject.Core.Models.Commands
{
    public class UserCreateCommand : ICommand
    {
        public long Id { get; set; }
    }
}
