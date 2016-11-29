using System;
using MyStudyProject.Core.Contracts.Interface;

namespace MyStudyProject.Core.Cqrs.Results.Command
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
