using System;
using System.Reflection;

using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Data.DataAccess.Context;
using HashtagAggregator.Domain.Cqrs.Common.Filters;
using HashtagAggregator.Domain.Cqrs.EF.Handlers.Queries;
using HashtagAggregator.Domain.Cqrs.Twitter.Handlers;
using HashtagAggregator.Domain.Cqrs.Vk.Handlers;
using HashtagAggregator.Shared.Common.Attributes;
using HashtagAggregator.Shared.Common.Settings;
using HashtagAggregator.Shared.Contracts.Enums;
using HashtagAggregator.Shared.Contracts.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace HashtagAggregator.Tests.Unit.Handlers
{
    public class RequestQueryFilterTest
    {
        [Fact]
        public void RequestVkQueryFilterAllowanceTest()
        {
            //Arrange          
            var vkFacadeMock = Mock.Of<IVkMessageFacade>();
            var vkHandler = new VkMessagesGetQueryHandler(vkFacadeMock);
            var vkAttribute = vkHandler.GetType().GetTypeInfo().GetCustomAttribute<DataSourceTypeAttribute>();
            ILogger<RequestQueryFilter> logger = Mock.Of<ILogger<RequestQueryFilter>>();
            var memoryCache = new Mock<IMemoryCacheWrapper>();
            memoryCache.Setup(m => m.Set(It.IsAny<string>(), It.IsAny<SocialMediaType>(), It.IsAny<TimeSpan>())).Returns(vkAttribute.MediaType);

            object o = SocialMediaType.VK;
            memoryCache.Setup(m => m.TryGetValue(It.IsAny<SocialMediaType>(), out o)).Returns(false);

            var settings = Options.Create(new InternetUpdateSettings());
            settings.Value.UpdatePeriod = 30000;
            
            var filter = new RequestQueryFilter(memoryCache.Object, settings, logger);

            //Act
            var vkAllowed = filter.IsRequestAllowed(vkHandler).Result;

            //Assert
            Assert.True(vkAllowed);
        }

        [Fact]
        public void RequestVkQueryFilterNotAllowanceTest()
        {
            //Arrange          
            var vkFacadeMock = Mock.Of<IVkMessageFacade>();
            var vkHandler = new VkMessagesGetQueryHandler(vkFacadeMock);
            var vkAttribute = vkHandler.GetType().GetTypeInfo().GetCustomAttribute<DataSourceTypeAttribute>();

            var memoryCache = new Mock<IMemoryCacheWrapper>();
            memoryCache.Setup(m => m.Set(It.IsAny<string>(), It.IsAny<SocialMediaType>(), It.IsAny<TimeSpan>())).Returns(vkAttribute.MediaType);
            ILogger<RequestQueryFilter> logger = Mock.Of<ILogger<RequestQueryFilter>>();
            object o = SocialMediaType.VK;
            memoryCache.Setup(m => m.TryGetValue(It.IsAny<SocialMediaType>(), out o)).Returns(false);

            var settings = Options.Create(new InternetUpdateSettings());
            settings.Value.UpdatePeriod = 30000;

            memoryCache.Setup(m => m.TryGetValue(It.IsAny<SocialMediaType>(), out o)).Returns(true);
            var filter = new RequestQueryFilter(memoryCache.Object, settings, logger);

            //Act
            var vkAllowed = filter.IsRequestAllowed(vkHandler).Result;
            //Assert
            Assert.False(vkAllowed);
        }

        [Fact]
        public void RequestTwitterQueryFilterAllowanceTest()
        {
            //Arrange          
            var twitterFacadeMock = Mock.Of<ITwitterMessageFacade>();
            var twiHandler = new TwitterMessagesGetQueryHandler(twitterFacadeMock);
            var twiAttribute = twiHandler.GetType().GetTypeInfo().GetCustomAttribute<DataSourceTypeAttribute>();

            var memoryCache = new Mock<IMemoryCacheWrapper>();
            memoryCache.Setup(m => m.Set(It.IsAny<string>(), It.IsAny<SocialMediaType>(), It.IsAny<TimeSpan>())).Returns(twiAttribute.MediaType);
            ILogger<RequestQueryFilter> logger = Mock.Of<ILogger<RequestQueryFilter>>();
            object o = SocialMediaType.Twitter;
            memoryCache.Setup(m => m.TryGetValue(It.IsAny<SocialMediaType>(), out o)).Returns(false);

            var settings = Options.Create(new InternetUpdateSettings());
            settings.Value.UpdatePeriod = 30000;

            var filter = new RequestQueryFilter(memoryCache.Object, settings, logger);

            //Act
            var twiAllowed = filter.IsRequestAllowed(twiHandler).Result;

            //Assert
            Assert.True(twiAllowed);
        }

        [Fact]
        public void RequestTwitterQueryFilterNotAllowanceTest()
        {
            //Arrange          

            var twitterFacadeMock = Mock.Of<ITwitterMessageFacade>();
            var twiHandler = new TwitterMessagesGetQueryHandler(twitterFacadeMock);
            var twiAttribute = twiHandler.GetType().GetTypeInfo().GetCustomAttribute<DataSourceTypeAttribute>();

            var memoryCache = new Mock<IMemoryCacheWrapper>();
            memoryCache.Setup(m => m.Set(It.IsAny<string>(), It.IsAny<SocialMediaType>(), It.IsAny<TimeSpan>())).Returns(twiAttribute.MediaType);
            ILogger<RequestQueryFilter> logger = Mock.Of<ILogger<RequestQueryFilter>>();
            object o = SocialMediaType.Twitter;
            memoryCache.Setup(m => m.TryGetValue(It.IsAny<SocialMediaType>(), out o)).Returns(true);

            var settings = Options.Create(new InternetUpdateSettings());
            settings.Value.UpdatePeriod = 30000;

            var filter = new RequestQueryFilter(memoryCache.Object, settings, logger);

            //Act
            var twiAllowed = filter.IsRequestAllowed(twiHandler).Result;

            //Assert
            Assert.False(twiAllowed);
        }

        [Fact]
        public void RequestEfQueryFilterAllowanceTest()
        {
            //Arrange          
            var dbSettings = new DbContextOptions<SqlApplicationDbContext>();
            var sqlContext = new SqlApplicationDbContext(dbSettings);
            var efHandler = new EfMessagesGetQueryHandler(sqlContext);
            var efAttribute = efHandler.GetType().GetTypeInfo().GetCustomAttribute<DataSourceTypeAttribute>();

            var memoryCache = new Mock<IMemoryCacheWrapper>();
            memoryCache.Setup(m => m.Set(It.IsAny<string>(), It.IsAny<SocialMediaType>(), It.IsAny<TimeSpan>())).Returns(null);

            object o = null;
            memoryCache.Setup(m => m.TryGetValue(It.IsAny<SocialMediaType>(), out o)).Returns(false);

            var settings = Options.Create(new InternetUpdateSettings());
            settings.Value.UpdatePeriod = 30000;

            var filter = new RequestQueryFilter(memoryCache.Object, settings, null);

            //Act
            var efAllowed = filter.IsRequestAllowed(efHandler).Result;

            //Assert
            Assert.True(efAllowed);
        }

        [Fact]
        public void RequestEfQueryFilterSecondAllowanceTest()
        {
            //Arrange

            var dbSettings = new DbContextOptions<SqlApplicationDbContext>();
            var sqlContext = new SqlApplicationDbContext(dbSettings);
            var efHandler = new EfMessagesGetQueryHandler(sqlContext);

            var memoryCache = new Mock<IMemoryCacheWrapper>();
            memoryCache.Setup(m => m.Set(It.IsAny<string>(), It.IsAny<SocialMediaType>(), It.IsAny<TimeSpan>())).Returns(null);

            object o = null;
            memoryCache.Setup(m => m.TryGetValue(It.IsAny<SocialMediaType>(), out o)).Returns(true);

            var settings = Options.Create(new InternetUpdateSettings());
            settings.Value.UpdatePeriod = 30000;

            var filter = new RequestQueryFilter(memoryCache.Object, settings, null);

            //Act
            var efAllowed = filter.IsRequestAllowed(efHandler).Result;

            //Assert
            Assert.True(efAllowed);
        }
    }
}
