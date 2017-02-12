using System;
using System.Collections.Generic;
using System.Linq;

using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Domain.Cqrs.EF.Assemblers;
using MyStudyProject.Shared.Contracts.Enums;

using Xunit;

namespace MyStudyProject.Tests.Unit.Mappers
{
    public class MessagesCommandToEntityMapperTest
    {
        [Fact]
        public void CompareMappedObjectsWithNullUserTest()
        {
            //Arrange
            var mapper = new MessagesCommandToEntityMapper();
            var command = GetMessageCommand("nicrosoft", null);
            //Act
            var result = mapper.MapBunch(new List<MessageCreateCommand> {command}).First();

            //Assert
            Assert.Equal(command.MessageText, result.MessageText);
            Assert.Equal(command.HashTag, result.HashTag);
            Assert.Equal(command.Id, result.Id);
            Assert.Equal(command.MediaType, result.MediaType);
            Assert.Equal(command.NetworkId, result.NetworkId);
            Assert.Equal(command.PostDate, result.PostDate);
            Assert.Null(result.User);
        }

        [Fact]
        public void CompareMappedObjectsTest()
        {
            //Arrange
            var mapper = new MessagesCommandToEntityMapper();
            var command = GetMessageCommand("nicrosoft", GetUserCommand());
            //Act
            var result = mapper.MapBunch(new List<MessageCreateCommand> { command }).First();

            //Assert
            Assert.Equal(command.MessageText, result.MessageText);
            Assert.Equal(command.HashTag, result.HashTag);
            Assert.Equal(command.Id, result.Id);
            Assert.Equal(command.MediaType, result.MediaType);
            Assert.Equal(command.NetworkId, result.NetworkId);
            Assert.Equal(command.PostDate, result.PostDate);
            Assert.NotNull(result.User);
        }

        private MessageCreateCommand GetMessageCommand(string hash, UserCreateCommand user)
        {
            var command = new MessageCreateCommand
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

