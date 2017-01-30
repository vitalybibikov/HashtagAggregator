using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Data.Contracts.Interface;
using MyStudyProject.Data.Contracts.Interface.JobObjects;
using Tweetinvi;
using Tweetinvi.Models;

namespace MyStudyProject.Data.Internet.Services.Twitter
{
    public class TwitterBackgroundJob : ITwitterBackgroundJob<MessageCreateCommand>
    {
        public TwitterBackgroundJob(ITwitterAuth auth)
        {
            auth.Authenticate();
        }

        public void Publish(MessageCreateCommand command)
        {
            //todo: check body on null

            var result = Tweet.PublishTweet(command.Body);
            var fail = ExceptionHandler.GetLastException().TwitterDescription;
            //todo: logging here
        }
    }
}
