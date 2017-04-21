using System;
using System.Linq;

using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Data.DataAccess.Context;
using HashtagAggregator.Domain.Cqrs.EF.Handlers.Commands;
using HashtagAggregator.Shared.Contracts.Enums;
using HashTagAggregator.Tests.DataHelpers;
using HashTagAggregator.Tests.DataHelpers.Common;
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
                var handler = new EfMesssagesCreateCommandHandler(context);

                var tags = CommandDataGenerator.GetHashTags(3);
                var user = CommandDataGenerator.GetUsers().FirstOrDefault();
                var command = CommandDataGenerator.GetCommands(tags, user, 1).FirstOrDefault();

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
                var tags = CommandDataGenerator.GetHashTags(3);
                var user = CommandDataGenerator.GetUsers().FirstOrDefault();
                var command = CommandDataGenerator.GetCommands(tags, user, 1).FirstOrDefault();
                var commands = new MessagesCreateCommand();
                commands.Messages.Add(command);

                //Act
                var response = handler.ExecuteAsync(commands);

                //Assert
                var result = context.Messages.FirstOrDefault(message => message.NetworkId == command.NetworkId);
                Assert.Equal(command.MessageText, result.MessageText);
            //    Assert.Equal(command.HashTag, result.HashTag);
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
                var tags = CommandDataGenerator.GetHashTags(3);
                var command = CommandDataGenerator.GetCommands(tags, null, 1).FirstOrDefault();
                var commands = new MessagesCreateCommand();
                commands.Messages.Add(command);

                //Act
                var response = handler.ExecuteAsync(commands);

                //Assert
                var result = context.Messages.FirstOrDefault(message => message.NetworkId == command.NetworkId);
                Assert.Null(result);
            }
        }
    }
}
