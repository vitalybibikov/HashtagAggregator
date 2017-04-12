using HashtagAggregator.Core.Models.Commands;

namespace HashtagAggregator.Core.Models
{
    public static class MessageCreateCommandExtensions
    {
        public static MessageCreateCommand BodyConvert(this MessageCreateCommand command, int maxLength)
        {
            command.MessageText = new MessageConverter().ConvertBody(command.MessageText, maxLength);
            return command;
        }
    }
}
