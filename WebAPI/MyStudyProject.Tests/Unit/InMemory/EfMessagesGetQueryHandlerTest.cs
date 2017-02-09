using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Data.DataAccess.Context;
using MyStudyProject.Data.Entities.Entities;
using MyStudyProject.Domain.Cqrs.EF.Assemblers;
using MyStudyProject.Domain.Cqrs.EF.Handlers;
using MyStudyProject.Shared.Contracts.Enums;
using Xunit;

namespace MyStudyProject.Tests.Unit.InMemory
{
    public class EfMessagesGetQueryHandlerTest
    {
        [Fact]
        public void CountLinesInDatabaseTest()
        {
            var options = new DbContextOptionsBuilder<SqlApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CountLinesInDatabaseTest")
                .Options;

            using (SqlApplicationDbContext context = new SqlApplicationDbContext(options))
            {
                //Arrange
                string hashtag = "#microsoft";
                EfMessagesGetQueryHandler handler = new EfMessagesGetQueryHandler(context);
                MessagesGetQuery query = new MessagesGetQuery { HashTag = hashtag };
                var data = GetData(hashtag);
                context.AddRange(data);
                context.SaveChanges();

                //Act
                var result = handler.GetAsync(query);

                //Assert
                Assert.Equal(GetData(hashtag).Count, result.Result.Messages.Count);
            }
        }

        [Fact]
        public void CompareLinesInDatabaseTest()
        {
            var options = new DbContextOptionsBuilder<SqlApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CompareLinesInDatabaseTest")
                .Options;

            using (SqlApplicationDbContext context = new SqlApplicationDbContext(options))
            {
                //Arrange
                string hashtag = "#microsoft";
                EfMessagesGetQueryHandler handler = new EfMessagesGetQueryHandler(context);
                MessagesGetQuery query = new MessagesGetQuery { HashTag = hashtag };
                EntityToMessagesResultMapper mapper = new EntityToMessagesResultMapper();
                var data = GetData(hashtag);
                context.AddRange(data);
                context.SaveChanges();

                //Act
                var result = handler.GetAsync(query);
                MessagesQueryResult mappedResult = mapper.MapBunch(data, hashtag);

                //Assert
                Assert.Equal(mappedResult.Messages, result.Result.Messages);
            }
        }

        private List<MessageEntity> GetData(string hashtag)
        {
            MessageEntity entity = new MessageEntity
            {
                MediaType = SocialMediaType.Twitter,
                MessageText = "TestBody",
                UserId = 0,
                PostDate = DateTime.Now,
                HashTag = hashtag,
                NetworkId = "2",

            };
            return new List<MessageEntity> { entity };
        }
    }
}
