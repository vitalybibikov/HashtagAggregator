//using System;
//using System.Collections.Generic;
//using System.Linq;

//using MyStudyProject.Data.Entities.Entities;
//using MyStudyProject.Domain.Cqrs.EF.Assemblers;
//using MyStudyProject.Shared.Contracts.Enums;

//using Xunit;

//namespace MyStudyProject.Tests.Unit.Mappers
//{
//    public class EntityToMessagesResultMapperTest
//    {
//        [Fact]
//        public void CompareMappedObjectsTest()
//        {
//            //Arrange
//            var mapper = new EntityToMessagesResultMapper();
//            var hash = "HashTag";
//            var command = new MessageEntity()
//            {
//                MessageText = "Body",
//                HashTag = hash,
//                Id = 33,
//                MediaType = SocialMediaType.Twitter,
//                NetworkId = "123",
//                PostDate = DateTime.Now,
//                UserId = "1123"
//            };
//            //Act
//            var result = mapper.MapBunch(new List<MessageEntity>() { command }, hash).Messages.First();

//            //Assert
//            Assert.Equal(command.User.UserId, result.User.NetworkId);
//            Assert.Equal(command.MessageText, result.Body);
//            Assert.Equal(command.HashTag, result.HashTag);
//            Assert.Equal(command.Id, result.Id);
//            Assert.Equal(command.MediaType, result.MediaType);
//            Assert.Equal(command.NetworkId, result.NetworkId);
//            Assert.Equal(command.PostDate, result.PostDate);
//        }
//    }
//}
