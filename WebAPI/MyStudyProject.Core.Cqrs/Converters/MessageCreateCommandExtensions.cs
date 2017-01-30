using System;

using MyStudyProject.Core.Models.Commands;

namespace MyStudyProject.Core.Cqrs.Converters
{
    public static class MessageCreateCommandExtensions
    {
        public static MessageCreateCommand BodyConvert(this MessageCreateCommand command, int maxLength)
        {
            if (!String.IsNullOrWhiteSpace(command.Body) && command.Body.Length > maxLength)
            {
                command.Body = command.Body.Substring(0, maxLength);
            }
            return command;
        }
    }
}
