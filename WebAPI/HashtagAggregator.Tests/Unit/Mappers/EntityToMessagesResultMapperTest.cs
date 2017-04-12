using System;
using System.Collections.Generic;
using System.Linq;
using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToResult;
using HashtagAggregator.Shared.Contracts.Enums;
using Xunit;

namespace HashtagAggregator.Tests.Unit.Mappers
{
    public class EntityToMessagesResultMapperTest
    {
        [Fact]
        public void CompareMappedObjectsWithNullUserTest()
        {
            //Arrange
            var mapper = new EntityToMessagesResultMapper();
            var hash = "HashTag";
            var command = GetMessageEntity(hash, null);
      
            //Act
            var result = mapper.MapBunch(new List<MessageEntity> { command }, hash).Messages.First();

            //Assert
            Assert.Equal(command.MessageText, result.MessageText);
            Assert.Equal(command.HashTag, result.HashTag);
            Assert.Equal(command.Id, result.Id);
            Assert.Equal(command.MediaType, result.MediaType);
            Assert.Equal(command.NetworkId, result.NetworkId);
            Assert.Equal(command.PostDate, result.PostDate);
        }

        [Fact]
        public void CompareMappedObjectsWithUserTest()
        {
            //Arrange
            var mapper = new EntityToMessagesResultMapper();
            var hash = "HashTag";

            var command = GetMessageEntity(hash, GetUserEntity());

            //Act
            var result = mapper.MapBunch(new List<MessageEntity> { command }, hash).Messages.First();

            //Assert
            Assert.Equal(command.MessageText, result.MessageText);
            Assert.Equal(command.HashTag, result.HashTag);
            Assert.Equal(command.Id, result.Id);
            Assert.Equal(command.MediaType, result.MediaType);
            Assert.Equal(command.NetworkId, result.NetworkId);
            Assert.Equal(command.PostDate, result.PostDate);
        }

        private MessageEntity GetMessageEntity(string hash, UserEntity user)
        {
            var command = new MessageEntity
            {
                MessageText = "Body",
                HashTag = hash,
                Id = 33,
                MediaType = SocialMediaType.Twitter,
                NetworkId = "123",
                PostDate = DateTime.Now,
                User = user
            };
            return command;
        }

        private UserEntity GetUserEntity()
        {
            var user = new UserEntity
            {
                UserName = null,
                NetworkId = "value",
                ProfileId = "id",
                Url = "url",
                Id = 3
            };
            return user;
        }
    }
}
