using System;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Core.Models.Results.Command;
using MyStudyProject.Data.Contracts.Interface;
using MyStudyProject.Data.Contracts.Interface.JobObjects;

using Tweetinvi;

namespace MyStudyProject.Data.Internet.Services.Twitter
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
                Data = Tweet.PublishTweet(command.Body)
            };
            if (String.IsNullOrEmpty(result.Message))
            {
                result.Success = true;
            }
            return result;
        }
    }
}
