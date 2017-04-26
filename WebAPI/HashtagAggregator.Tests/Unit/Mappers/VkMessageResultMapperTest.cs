using System;
using System.Collections.Generic;
using System.Linq;

using HashtagAggregator.Core.Entities.VkEntities;
using HashtagAggregator.Data.Internet.Assemblers;
using HashtagAggregator.Data.Internet.Vk.Assemblers;
using HashtagAggregator.Shared.Common.Infrastructure;
using HashtagAggregator.Shared.Contracts.Enums;
using HashTagAggregator.Tests.DataHelpers.VK;

using Xunit;

namespace HashtagAggregator.Tests.Unit.Mappers
{
    public class VkMessageResultMapperTest
    {
        [Fact]
        public void TestVkMessageSingleMap()
        {
            //Arrange
            var hash = new HashTagWord("hash");
            var search = VkDataGenerator.GetSearches().FirstOrDefault();
            var profile = VkDataGenerator.GetProfiles(search.FromId).FirstOrDefault();

            var date = DateTimeOffset.FromUnixTimeSeconds(search.UnixTimeStamp).DateTime;
            var feed = new VkNewsFeed
            {
                Feed = new List<VkNewsSearchResult> { search },
                Profiles = new List<VkNewsProfile> { profile }
            };
            var mapper = new VkMessageResultMapper();

            //Act
            var result = mapper.MapSingle(feed, hash);
            
            //Assert
            foreach (var message in result.Messages)
            {
                Assert.Equal(search.Text, message.MessageText);

                Assert.Equal(1, message.HashTags.Count);
                Assert.Equal(SocialMediaType.VK, message.MediaType);
                Assert.Equal(search.Id.ToString(), message.NetworkId);
                Assert.Equal(date, message.PostDate);
                Assert.Equal($"{profile.FirstName} {profile.LastName}", message.User.UserName);
                Assert.Equal(profile.UserName, message.User.ProfileId);
                Assert.Equal(profile.Id.ToString(), message.User.NetworkId);
            }
        }
    }
}