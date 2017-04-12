using HashtagAggregator.Data.Internet.DataSources.Twitter;
using HashtagAggregator.Domain.Cqrs.Twitter.Handlers;
using HashtagAggregator.Shared.Common.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace HashtagAggregator.Tests.Unit.Handlers
{
    public class TwitterMesssagesCreateCommandHandlerTest
    {
        public void TestTwitterCreateMessage()
        {
            var settings = Options.Create(new TwitterApiSettings());
            var authSettings = Options.Create(new TwitterAuthSettings());
            var auth = new TwitterAuth(authSettings);
            var loggerMock = Mock.Of<ILogger<TwitterMessageServiceFacade>>();


            var service = new TwitterMessageServiceFacade(settings, auth, loggerMock);
            var handler = new TwitterMesssagesCreateCommandHandler(service);
        }
    }
}
