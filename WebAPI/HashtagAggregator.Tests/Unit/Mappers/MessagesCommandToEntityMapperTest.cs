using System.Linq;

using HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToEnity;
using HashTagAggregator.Tests.DataHelpers;
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

            var hashCount = 3;
            var hashCommand = CommandDataGenerator.GetHashTags(hashCount);
            var commands = CommandDataGenerator.GetMessages(hashCommand, null);

            //Act
            var result = mapper.MapBunch(commands).First();
            var command = commands.FirstOrDefault();

            //Assert
            Assert.Equal(result.MessageText, command.MessageText);
            Assert.Equal(result.HashTags.Count, hashCount);
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
            var hashCommand = CommandDataGenerator.GetHashTags(3);
            var userCommand = CommandDataGenerator.GetUsers().FirstOrDefault();
            var commands = CommandDataGenerator.GetMessages(hashCommand, userCommand);

            //Act
            var result = mapper.MapBunch(commands).First();

            var command = commands.FirstOrDefault();

            //Assert
            Assert.Equal(result.MessageText, command.MessageText);
            Assert.Equal(result.HashTags.Count, hashCommand.Count);
            Assert.Equal(result.Id, command.Id);
            Assert.Equal(result.MediaType, command.MediaType);
            Assert.Equal(result.NetworkId, command.NetworkId);
            Assert.Equal(result.PostDate, command.PostDate);
            Assert.NotNull(result.User);
        }
    }
}

