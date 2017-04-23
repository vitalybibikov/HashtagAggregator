using System.Linq;

using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToEnity;
using HashtagAggregator.Shared.Contracts.Enums;
using HashTagAggregator.Tests.DataHelpers;

using Xunit;

namespace HashtagAggregator.Tests.Unit.Mappers
{
    public class UserCommandToEntityMapperTest
    {
        [Fact]
        public void CompareMappedObjectsWithNullUserTest()
        {
            //Arrange
            var mapper = new UserCommandToEntityMapper();
            var command = CommandDataGenerator.GetUsers().FirstOrDefault();

            //Act
            var result = mapper.MapSingle(command);

            //Assert
            Assert.Equal(command.Id, result.Id);
            Assert.Equal(command.NetworkId, result.NetworkId);
            Assert.Equal(command.ProfileId, result.ProfileId);
            Assert.Equal(command.Url, result.Url);
            Assert.Equal(command.UserName, result.UserName);
            Assert.Equal(command.MediaType, result.MediaType);
            Assert.Equal(command.AvatarUrl50, result.AvatarUrl50);
        }
    }
}