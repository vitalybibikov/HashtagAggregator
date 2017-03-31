using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using MyStudyProject.Data.Internet.DataSources.Twitter;
using MyStudyProject.Domain.Cqrs.Twitter.Handlers;
using MyStudyProject.Shared.Common.Settings;

namespace MyStudyProject.Tests.Unit.Handlers
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
