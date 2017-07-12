using System.Collections.Generic;
using System.Linq;

using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query.Message;
using HashtagAggregator.Data.DataAccess.Context;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToResult;
using HashtagAggregator.Domain.Cqrs.EF.Handlers.Queries;
using HashtagAggregator.Shared.Common.Infrastructure;
using HashTagAggregator.Tests.DataHelpers;

using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HashtagAggregator.Tests.Unit.InMemory
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
                var hashtag = new HashTagWord("microsoft");
                var handler = new EfMessagesGetQueryHandler(context);
                var query = new MessagesQuery { HashTag = hashtag };
                var data = GetData(hashtag);

                InsertData(data, context);
                context.SaveChanges();

                //Act
                var result = handler.Handle(query).Result;

                //Assert
                Assert.Equal(data.Count, result.Messages.Count);
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
                var hashtag = new HashTagWord("microsoft");
                var handler = new EfMessagesGetQueryHandler(context);
                var query = new MessagesQuery { HashTag = hashtag };
                var mapper = new EntityToMessagesResultMapper();
                var data = GetData(hashtag);

                InsertData(data, context);
                context.SaveChanges();

                //Act
                var result = handler.Handle(query);
                MessagesQueryResult mappedResult = mapper.MapBunch(data, hashtag);

                //Assert
                Assert.Equal(mappedResult.Messages, result.Result.Messages);
            }
        }

        private List<MessageEntity> GetData(params HashTagWord[] tags)
        {
            var user = EntityDataGenerator.GetUsers().FirstOrDefault();
            return EntityDataGenerator.GetMessages(user, 1, tags);
        }

        private void InsertData(List<MessageEntity> messages, SqlApplicationDbContext context)
        {
            foreach (var message in messages)
            {
                context.Users.Add(message.User);

                message.PostDate = message.PostDate?.ToUniversalTime();
                context.Messages.Add(message);

                foreach (var tag in message.HashTags)
                {
                    var tagToLink = context.Hashtags.FirstOrDefault(x => x.HashTag == tag.HashTag) ?? tag;

                    var tag2Message = new MessageHashTagRelationsEntity
                    {
                        HashTagEntity = tagToLink,
                        MessageEntity = message
                    };
                    context.TaggedMessages.Add(tag2Message);

                    if (tagToLink.IsNew)
                    {
                        context.Hashtags.Add(tagToLink);
                    }
                }
            }
        }
    }
}
