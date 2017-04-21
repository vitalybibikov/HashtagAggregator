using System;
using System.Collections.Generic;
using System.Linq;

using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToEnity;
using HashtagAggregator.Shared.Contracts.Enums;
using Xunit;

namespace HashtagAggregator.Tests.Unit.Mappers
{
    public class MessagesCommandToEntityMapperTest
    {
        [Fact]
        public void CompareMappedObjectsWithNullUserTest()
        {
            //Arrange
            var mapper = new MessagesCommandToEntityMapper();
            var command = GetMessageCommand(null);
            //Act
            var result = mapper.MapBunch(new List<MessageCreateCommand> {command}).First();

            //Assert
            Assert.Equal(result.MessageText, command.MessageText);
            Assert.Equal(result.HashTags.Count, 0);
            Assert.Equal(result.Id, command.Id);
            Assert.Equal(result.MediaType, command.MediaType);
            Assert.Equal(result.NetworkId, command.NetworkId);
            Assert.Equal(result.PostDate, command.PostDate);
            Assert.Null(result.User);
        }

        [Fact]
        public void CompareMappedObjectsTest()
        {
            //Arrange
            var mapper = new MessagesCommandToEntityMapper();
            var param = new List<string> { "nicrosoft", "hashtag" };
            var command = GetMessageCommand(GetUserCommand(), param.ToArray());

            //Act
            var result = mapper.MapBunch(
                new List<MessageCreateCommand> { command }).First();

            //Assert
            Assert.Equal(result.MessageText, command.MessageText);
            Assert.Equal(result.HashTags.Count, param.Count);
            Assert.Equal(result.Id, command.Id);
            Assert.Equal(result.MediaType, command.MediaType);
            Assert.Equal(result.NetworkId, command.NetworkId);
            Assert.Equal(result.PostDate, command.PostDate);
            Assert.NotNull(result.User);
        }

        private MessageCreateCommand GetMessageCommand(UserCreateCommand user, params string [] tags)
        {
            var command = new MessageCreateCommand
            {
                MessageText = "Body",
                Id = 33,
                MediaType = SocialMediaType.Twitter,
                NetworkId = "123",
                PostDate = DateTime.Now,
                User = user
            };

            foreach (var tag in tags)
            {
                command.HashTags.Add(new HashTagCreateCommand {HashTag = tag});
            }

            return command;
        }

        private UserCreateCommand GetUserCommand()
        {
            var user = new UserCreateCommand
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

