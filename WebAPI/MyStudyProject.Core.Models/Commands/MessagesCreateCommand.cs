using System;
using System.Collections.Generic;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;

namespace MyStudyProject.Core.Models.Commands
{
    public class MessagesCreateCommand : ICommand
    {
        public MessagesCreateCommand()
        {
            Messages = new List<MessageCreateCommand>();
        }

        public List<MessageCreateCommand> Messages { get; set; }
    }
}
