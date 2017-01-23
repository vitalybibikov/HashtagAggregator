using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using MyStudyProject.Core.Cqrs.RequestFilter;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Data.Contracts.ServiceFacades;
using MyStudyProject.Data.DataAccess.Context;
using MyStudyProject.Domain.Cqrs.EF.Handlers;
using MyStudyProject.Domain.Cqrs.Twitter.Handlers;
using MyStudyProject.Domain.Cqrs.Vk.Handlers;
using MyStudyProject.Shared.Common.Attributes;
using MyStudyProject.Shared.Common.Settings;
using MyStudyProject.Shared.Contracts.Enums;
using MyStudyProject.Shared.Contracts.Interfaces;
using Xunit;

namespace MyStudyProject.Tests.Unit.Handlers
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
  
            var memoryCache = new Mock<IMemoryCacheWrapper>();
            memoryCache.Setup(m => m.Set(It.IsAny<string>(), It.IsAny<SocialMediaType>(), It.IsAny<TimeSpan>())).Returns(vkAttribute.MediaType);

            object o = SocialMediaType.VK;
            memoryCache.Setup(m => m.TryGetValue(It.IsAny<SocialMediaType>(), out o)).Returns(false);

            var settings = Options.Create(new InternetUpdateSettings());
            settings.Value.UpdatePeriod = 30000;
            
            var filter = new RequestQueryFilter(memoryCache.Object, settings);

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

            object o = SocialMediaType.VK;
            memoryCache.Setup(m => m.TryGetValue(It.IsAny<SocialMediaType>(), out o)).Returns(false);

            var settings = Options.Create(new InternetUpdateSettings());
            settings.Value.UpdatePeriod = 30000;

            memoryCache.Setup(m => m.TryGetValue(It.IsAny<SocialMediaType>(), out o)).Returns(true);
            var filter = new RequestQueryFilter(memoryCache.Object, settings);

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

            object o = SocialMediaType.Twitter;
            memoryCache.Setup(m => m.TryGetValue(It.IsAny<SocialMediaType>(), out o)).Returns(false);

            var settings = Options.Create(new InternetUpdateSettings());
            settings.Value.UpdatePeriod = 30000;

            var filter = new RequestQueryFilter(memoryCache.Object, settings);

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

            object o = SocialMediaType.Twitter;
            memoryCache.Setup(m => m.TryGetValue(It.IsAny<SocialMediaType>(), out o)).Returns(true);

            var settings = Options.Create(new InternetUpdateSettings());
            settings.Value.UpdatePeriod = 30000;

            var filter = new RequestQueryFilter(memoryCache.Object, settings);

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

            var filter = new RequestQueryFilter(memoryCache.Object, settings);

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
            var efAttribute = efHandler.GetType().GetTypeInfo().GetCustomAttribute<DataSourceTypeAttribute>();

            var memoryCache = new Mock<IMemoryCacheWrapper>();
            memoryCache.Setup(m => m.Set(It.IsAny<string>(), It.IsAny<SocialMediaType>(), It.IsAny<TimeSpan>())).Returns(null);

            object o = null;
            memoryCache.Setup(m => m.TryGetValue(It.IsAny<SocialMediaType>(), out o)).Returns(true);

            var settings = Options.Create(new InternetUpdateSettings());
            settings.Value.UpdatePeriod = 30000;

            var filter = new RequestQueryFilter(memoryCache.Object, settings);

            //Act
            var efAllowed = filter.IsRequestAllowed(efHandler).Result;

            //Assert
            Assert.True(efAllowed);
        }
    }
}
