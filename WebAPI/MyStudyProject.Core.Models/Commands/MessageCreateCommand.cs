using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;

namespace MyStudyProject.Core.Models.Commands
{
    public class MessageCreateCommand : ICommand
    {
        public long Id { get; set; }
    }
}
