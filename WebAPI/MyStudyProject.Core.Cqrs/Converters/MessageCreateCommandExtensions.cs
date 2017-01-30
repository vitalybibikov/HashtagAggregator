using System;

using MyStudyProject.Core.Models.Commands;

namespace MyStudyProject.Core.Cqrs.Converters
{
    public static class MessageCreateCommandExtensions
    {
        public static MessageCreateCommand BodyConvert(this MessageCreateCommand command, int maxLength)
        {
            command.Body = new MessageConverter().ConvertBody(command.Body, maxLength);
            return command;
        }
    }
}
