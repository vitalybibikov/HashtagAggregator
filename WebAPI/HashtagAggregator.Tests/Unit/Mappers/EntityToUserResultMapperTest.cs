using System;
using System.Collections.Generic;
using System.Linq;
using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToResult;
using HashtagAggregator.Shared.Common.Infrastructure;
using HashTagAggregator.Tests.DataHelpers;
using Xunit;

namespace HashtagAggregator.Tests.Unit.Mappers
{
    public class EntityToUserResultMapperTest
    {
            
        [Fact]
        public void CompareMappedObjectsWithNullUserTest()
        {
            //Arrange
            var mapper = new EntityToUserResultMapper();
            var user = EntityDataGenerator.GetUsers().FirstOrDefault();

            //Act
            var result = mapper.MapSingle(user);

            //Assert
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.AvatarUrl50, result.AvatarUrl50);
            Assert.Equal(user.MediaType, result.MediaType);
            Assert.Equal(user.NetworkId, result.NetworkId);
            Assert.Equal(user.ProfileId, result.ProfileId);
            Assert.Equal(user.UserName, result.UserName);
            Assert.Equal(user.Url, result.Url);
        }
    }
}
