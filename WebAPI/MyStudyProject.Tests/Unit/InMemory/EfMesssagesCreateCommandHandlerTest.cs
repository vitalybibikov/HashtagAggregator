using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Data.DataAccess.Context;
using MyStudyProject.Domain.Cqrs.EF.Handlers;
using MyStudyProject.Shared.Contracts.Enums;

using Xunit;

namespace MyStudyProject.Tests.Unit.InMemory
{
    public class EfMesssagesCreateCommandHandlerTest
    {

        //[Fact]
        //public void MessageCommandCountLinesInDatabaseTest()
        //{
        //    var options = new DbContextOptionsBuilder<SqlApplicationDbContext>()
        //        .UseInMemoryDatabase(databaseName: "MessageCommandCountLinesInDatabaseTest")
        //        .Options;

        //    using (SqlApplicationDbContext context = new SqlApplicationDbContext(options))
        //    {
        //        //Arrange
        //        string hashtag = "#microsoft";
        //        var handler = new EfMesssagesCreateCommandHandler(context);

        //        var command = GetCommands(hashtag);
        //        MessagesCreateCommand commands = new MessagesCreateCommand();
        //        commands.Messages.Add(command);

        //        //Act
        //        var response = handler.ExecuteAsync(commands);
        //        var result = context.Messages.Count();

        //        //Assert
        //        Assert.Equal(commands.Messages.Count(), result);
        //    }
        //}

        //[Fact]
        //public void MessagesCommandCompareTest()
        //{
        //    var options = new DbContextOptionsBuilder<SqlApplicationDbContext>()
        //        .UseInMemoryDatabase(databaseName: "MessagesCommandCompareTest")
        //        .Options;

        //    using (SqlApplicationDbContext context = new SqlApplicationDbContext(options))
        //    {
        //        //Arrange
        //        string hashtag = "#microsoft";
        //        var handler = new EfMesssagesCreateCommandHandler(context);

        //        var command = GetCommands(hashtag);
        //        MessagesCreateCommand commands = new MessagesCreateCommand();
        //        commands.Messages.Add(command);

        //        //Act
        //        var response = handler.ExecuteAsync(commands);

        //        //Assert
        //        var result =
        //            context.Messages.First(message => message.NetworkId == command.NetworkId
        //                           && message.UserId == command.UserId);

        //        Assert.Equal(command.UserId, result.UserId);
        //        Assert.Equal(command.Body, result.MessageText);
        //        Assert.Equal(command.HashTag, result.HashTag);
        //        Assert.Equal(command.Id, result.Id);
        //        Assert.Equal(command.MediaType, result.MediaType);
        //        Assert.Equal(command.NetworkId, result.NetworkId);
        //        Assert.Equal(command.PostDate, result.PostDate);
        //    }
        //}

        //private MessageCreateCommand GetCommands(string hashtag)
        //{
        //    MessageCreateCommand command = new MessageCreateCommand
        //    {
        //        MediaType = SocialMediaType.Twitter,
        //        Body = "TestBody",
        //        UserId = "1",
        //        PostDate = DateTime.Now,
        //        HashTag = hashtag,
        //        NetworkId = "2",
        //        Id = 1
        //    };
        //    return command;
        //}
    }
}
