using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;

namespace MyStudyProject.Core.Models.Results.Command
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
