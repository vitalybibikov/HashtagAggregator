using System;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results;
using HashtagAggregator.Data.Contracts.Interface;
using HashtagAggregator.Data.Contracts.Interface.JobObjects;
using Tweetinvi;

namespace HashtagAggregator.Data.Internet.DataSources.Twitter
{
    public class TwitterBackgroundJob : ITwitterBackgroundJob<MessageCreateCommand>
    {
        public TwitterBackgroundJob(ITwitterAuth auth)
        {
            auth.Authenticate();
        }

        public ICommandResult Publish(MessageCreateCommand command)
        {
            CommandResult result = new CommandResult
            {
                Message = ExceptionHandler.GetLastException()?.TwitterDescription,
                Data = Tweet.PublishTweet(command.MessageText)
            };
            if (String.IsNullOrEmpty(result.Message))
            {
                result.Success = true;
            }
            return result;
        }
    }
}
