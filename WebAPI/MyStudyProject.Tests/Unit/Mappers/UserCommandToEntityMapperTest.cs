using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Domain.Cqrs.EF.Assemblers;

using Xunit;

namespace MyStudyProject.Tests.Unit.Mappers
{
    public class UserCommandToEntityMapperTest
    {
        [Fact]
        public void CompareMappedObjectsWithNullUserTest()
        {
            //Arrange
            var mapper = new UserCommandToEntityMapper();
            var command = GetUserCommand();
            //Act
            var result = mapper.MapSingle(command);

            //Assert
            Assert.Equal(command.Id, result.Id);
            Assert.Equal(command.NetworkId, result.NetworkId);
            Assert.Equal(command.ProfileId, result.ProfileId);
            Assert.Equal(command.Url, result.Url);
            Assert.Equal(command.UserName, result.UserName);
        }

        private UserCreateCommand GetUserCommand()
        {
            var user = new UserCreateCommand
            {
                UserName = null,
                NetworkId = "value",
                ProfileId = "id",
                Url = "url"
            };
            return user;
        }
    }
}