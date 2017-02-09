using System;
using System.Collections.Generic;

using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Data.Internet.Assemblers.Vk;
using MyStudyProject.Data.Internet.Services.Vk;
using MyStudyProject.Shared.Contracts.Enums;
using MyStudyProject.Tests.TestHelpers;
using Xunit;

namespace MyStudyProject.Tests.Unit.Mappers
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
                Assert.Equal(search.Text, message.Text);
                Assert.Equal(hash, message.HashTag);
                Assert.Equal(SocialMediaType.VK, message.MediaType);
                Assert.Equal(search.Id.ToString(), message.NetworkId);
                Assert.Equal(date, message.PostDate);
                Assert.Equal($"{profile.FirstName} {profile.LastName}", message.User.UserName);
                Assert.Equal(profile.UserName, message.User.ProfileId);
                Assert.Equal(profile.Id.ToString(), message.User.NetworkId);
            };
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