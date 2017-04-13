using System;
using System.Collections.Generic;
using HashtagAggregator.Core.Entities.VkEntities;
using HashtagAggregator.Core.Models.Results.Query;
using HashtagAggregator.Core.Models.Results.Query.Message;
using HashtagAggregator.Data.Internet.Assemblers;
using HashtagAggregator.Shared.Contracts.Enums;
using HashtagAggregator.Tests.TestHelpers;
using Xunit;

namespace HashtagAggregator.Tests.Unit.Mappers
{
    public class VkMessageResultMapperTest
    {
        [Fact]
        public void TestVkMessageSingleMap()
        {
            //Arrange
            var hash = "hash";
            VkNewsSearchResult search = GetSearch();
            VkNewsProfile profile = GetProfile();
            var date = DateTimeOffset.FromUnixTimeSeconds(search.UnixTimeStamp).DateTime;
            VkNewsFeed feed = new VkNewsFeed
            {
                Feed = new List<VkNewsSearchResult> { search },
                Profiles = new List<VkNewsProfile> { profile }
            };
            var mapper = new VkMessageResultMapper();

            //Act
            var result = mapper.MapSingle(feed, hash);
            
            //Assert
            foreach (MessageQueryResult message in result.Messages)
            {
                Assert.Equal(search.Text, message.MessageText);
                Assert.Equal(hash, message.HashTag);
                Assert.Equal(SocialMediaType.VK, message.MediaType);
                Assert.Equal(search.Id.ToString(), message.NetworkId);
                Assert.Equal(date, message.PostDate);
                Assert.Equal($"{profile.FirstName} {profile.LastName}", message.User.UserName);
                Assert.Equal(profile.UserName, message.User.ProfileId);
                Assert.Equal(profile.Id.ToString(), message.User.NetworkId);
            }
        }

        private static VkNewsSearchResult GetSearch()
        {
            return new VkNewsSearchResult
            {
                FromId = 123123,
                Id = 123123,
                OwnerId = 123123,
                Text = "Text",
                UnixTimeStamp = DateTime.Now.ToUnixTime()
            };
        }

        private static VkNewsProfile GetProfile()
        {
            return new VkNewsProfile
            {
                FirstName = "FirstName",
                Id = 123123,
                LastName = "LastName",
                UserName = "UserName"
            };
        }
    }
}