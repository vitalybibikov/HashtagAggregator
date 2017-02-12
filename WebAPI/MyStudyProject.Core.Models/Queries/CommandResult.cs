using MyStudyProject.Core.Models.Interface.Cqrs.Command;

namespace MyStudyProject.Core.Models.Queries
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
