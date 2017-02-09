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
        //[Fact]
        //public void CompareMappedObjectsTest()
        //{
        //    //Arrange
        //    var mapper = new MessagesCommandToEntityMapper();
        //    var command = new MessageCreateCommand()
        //    {
        //        Body = "Body",
        //        HashTag = "HashTag",
        //        Id = 33,
        //        MediaType = SocialMediaType.Twitter,
        //        NetworkId = "123",
        //        PostDate = DateTime.Now,
        //        UserId = "1123"
        //    };
        //    //Act
        //    var result = mapper.MapBunch(new List<MessageCreateCommand>() { command }).First();

        //    //Assert
        //    Assert.Equal(command.UserId, result.UserId);
        //    Assert.Equal(command.Body, result.MessageText);
        //    Assert.Equal(command.HashTag, result.HashTag);
        //    Assert.Equal(command.Id, result.Id);
        //    Assert.Equal(command.MediaType, result.MediaType);
        //    Assert.Equal(command.NetworkId, result.NetworkId);
        //    Assert.Equal(command.PostDate, result.PostDate);
        //}
    }
}

