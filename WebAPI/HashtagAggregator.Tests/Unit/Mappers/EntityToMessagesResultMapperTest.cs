using System;
using System.Collections.Generic;
using System.Linq;
using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToResult;
using HashtagAggregator.Shared.Common.Infrastructure;
using HashtagAggregator.Shared.Contracts.Enums;
using HashTagAggregator.Tests.DataHelpers;
using Xunit;

namespace HashtagAggregator.Tests.Unit.Mappers
{
    public class EntityToMessagesResultMapperTest
    {
        [Fact]
        public void CompareMappedObjectsWithNullUserTest()
        {
            //Arrange
            var mapper = new EntityToMessagesResultMapper();
            var hash = new HashTagWord("hash");

            var user = EntityDataGenerator.GetUsers();
            var entities = EntityDataGenerator.GetMessages(user.FirstOrDefault(), 1, hash);

            //Act
            var result = mapper.MapBunch(entities, hash).Messages.First();

            //Assert
            var entity = entities.FirstOrDefault();

            Assert.Equal(entity.MessageText, result.MessageText);
            Assert.Equal(entity.HashTags.Count, 1);
            Assert.Equal(entity.Id, result.Id);
            Assert.Equal(entity.MediaType, result.MediaType);
            Assert.Equal(entity.NetworkId, result.NetworkId);
            Assert.Equal(entity.PostDate, result.PostDate);
        }

        [Fact]
        public void CompareMappedObjectsWithUserTest()
        {
            //Arrange
            var mapper = new EntityToMessagesResultMapper();
            var tagsCount = 1;
            var hash = new HashTagWord("hash");

            var user = EntityDataGenerator.GetUsers();
            var entities = EntityDataGenerator.GetMessages(user.FirstOrDefault(), 1, hash);

            //Act
            var result = mapper.MapBunch(entities, hash).Messages.First();

            //Assert
            var entity = entities.FirstOrDefault();

            Assert.Equal(entity.MessageText, result.MessageText);
            Assert.Equal(entity.HashTags.Count, tagsCount);
            Assert.Equal(entity.Id, result.Id);
            Assert.Equal(entity.MediaType, result.MediaType);
            Assert.Equal(entity.NetworkId, result.NetworkId);
            Assert.Equal(entity.PostDate, result.PostDate);
        }
    }
}
