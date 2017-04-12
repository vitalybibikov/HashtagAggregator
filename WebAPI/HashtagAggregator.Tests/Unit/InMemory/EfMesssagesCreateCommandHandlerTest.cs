using System;
using System.Linq;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Data.DataAccess.Context;
using HashtagAggregator.Domain.Cqrs.EF.Handlers;
using HashtagAggregator.Shared.Contracts.Enums;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HashtagAggregator.Tests.Unit.InMemory
{
    public class EfMesssagesCreateCommandHandlerTest
    {
        [Fact]
        public void MessageCommandCountLinesInDatabaseTest()
        {
            var options = new DbContextOptionsBuilder<SqlApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MessageCommandCountLinesInDatabaseTest")
                .Options;

            using (SqlApplicationDbContext context = new SqlApplicationDbContext(options))
            {
                //Arrange
                string hashtag = "#microsoft";
                var handler = new EfMesssagesCreateCommandHandler(context);

                var command = GetCommands(hashtag, GetUser());
                MessagesCreateCommand commands = new MessagesCreateCommand();
                commands.Messages.Add(command);

                //Act
                var response = handler.ExecuteAsync(commands);
                var result = context.Messages.Count();

                //Assert
                Assert.Equal(commands.Messages.Count(), result);
            }
        }

        [Fact]
        public void MessagesCommandCreateTest()
        {
            var options = new DbContextOptionsBuilder<SqlApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MessagesCommandCompareTest")
                .Options;

            using (SqlApplicationDbContext context = new SqlApplicationDbContext(options))
            {
                //Arrange
                string hashtag = "#microsoft";
                var handler = new EfMesssagesCreateCommandHandler(context);

                MessageCreateCommand command = GetCommands(hashtag, GetUser());
                MessagesCreateCommand commands = new MessagesCreateCommand();
                commands.Messages.Add(command);

                //Act
                var response = handler.ExecuteAsync(commands);

                //Assert
                var result = context.Messages.FirstOrDefault(message => message.NetworkId == command.NetworkId);
                Assert.Equal(command.MessageText, result.MessageText);
                Assert.Equal(command.HashTag, result.HashTag);
                Assert.Equal(command.Id, result.Id);
                Assert.Equal(command.MediaType, result.MediaType);
                Assert.Equal(command.NetworkId, result.NetworkId);
                Assert.Equal(command.PostDate.Value.ToUniversalTime(), result.PostDate.Value.ToUniversalTime());
            }
        }

        [Fact]
        public void MessageWithNullUserNotCreatedTest()
        {
            var options = new DbContextOptionsBuilder<SqlApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MessagesCommandCompareTest")
                .Options;

            using (SqlApplicationDbContext context = new SqlApplicationDbContext(options))
            {
                //Arrange
                string hashtag = "#microsoft";
                var handler = new EfMesssagesCreateCommandHandler(context);

                MessageCreateCommand command = GetCommands(hashtag, null);
                MessagesCreateCommand commands = new MessagesCreateCommand();
                commands.Messages.Add(command);

                //Act
                var response = handler.ExecuteAsync(commands);

                //Assert
                var result = context.Messages.FirstOrDefault(message => message.NetworkId == command.NetworkId);
                Assert.Null(result);
            }
        }

        private MessageCreateCommand GetCommands(string hashtag, UserCreateCommand user)
        {
            MessageCreateCommand command = new MessageCreateCommand
            {
                MediaType = SocialMediaType.Twitter,
                MessageText = "TestBody",
                PostDate = DateTime.Now,
                HashTag = hashtag,
                NetworkId = "2",
                Id = 1,
                User = user
            };
            return command;
        }

        private UserCreateCommand GetUser()
        {
            UserCreateCommand user = new UserCreateCommand()
            {
                Id = 0,
                NetworkId = "1",
                ProfileId = "1",
                Url = "http://sdf.com",
                UserName = "Name"
            };
            return user;
        }
    }
}
