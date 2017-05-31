using System;
using System.Collections.Generic;

using HashtagAggregator.Data.Internet.Assemblers;
using HashtagAggregator.Shared.Contracts.Enums;

using Tweetinvi.Logic.TwitterEntities;
using Tweetinvi.Models;
using Tweetinvi.Models.Entities;

using Xunit;
using Moq;
namespace HashtagAggregator.Tests.Unit.Mappers
{
    public class TwitterMessageResultMapperTest
    {
        [Fact]
        public void TestTwitterMessageSingleMap()
        {
            //Arrange
            var mapper = new TwitterMessageResultMapper();
            var tweetMock = new Mock<ITweet>();
            var hash = "hash";
            tweetMock.SetupGet(x => x.Url).Returns("url");
            tweetMock.SetupGet(x => x.Text).Returns("Text");
            tweetMock.SetupGet(x => x.CreatedBy.IdStr).Returns("UserId");
            tweetMock.SetupGet(x => x.IdStr).Returns("IdStr");
            tweetMock.SetupGet(x => x.TweetLocalCreationDate).Returns(DateTime.MaxValue);

            tweetMock.SetupGet(x => x.Hashtags).Returns(() => 
                new List<IHashtagEntity>
                {
                    new HashtagEntity {Text = hash}
                });


            var tweet = tweetMock.Object; //add hashtag to mock

            //Act
            var result = mapper.MapSingle(tweet);

            //Assert
            Assert.Equal(tweet.Url, result.User.Url);
            Assert.Equal(tweet.Text, result.MessageText);
            Assert.Equal(result.HashTags.Count, 1);
            Assert.Equal(result.HashTags[0].HashTag.NoHashTag, hash);
            Assert.Equal(tweet.IdStr, result.NetworkId);
            Assert.Equal(SocialMediaType.Twitter, result.MediaType);
            Assert.Equal(tweet.TweetLocalCreationDate.ToUniversalTime(), result.PostDate.Value.ToUniversalTime());
        }
    }
}
