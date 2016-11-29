using MyStudyProject.Core.Contracts.Interface.Cqrs;

namespace MyStudyProject.Core.Models.Commands
{
    public class MessageCreateCommand : ICommand
    {
        public long Id { get; set; }
    }
}
