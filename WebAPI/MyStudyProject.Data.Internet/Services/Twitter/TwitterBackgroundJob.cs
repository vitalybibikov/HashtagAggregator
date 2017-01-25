using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Data.Contracts.Interface;

using Tweetinvi;

namespace MyStudyProject.Data.Internet.Services.Twitter
{
    public class TwitterBackgroundJob : ITwitterBackgroundJob<MessageCreateCommand>
    {
        public TwitterBackgroundJob(ITwitterAuth auth)
        {
            auth.Authenticate();
        }

        public void PublishTweet(MessageCreateCommand command)
        {
            //todo: check body on null
            var result = Tweet.PublishTweet(command.Body);
            var fail = ExceptionHandler.GetLastException().TwitterDescription;
            //todo: logging here
        }
    }
}
