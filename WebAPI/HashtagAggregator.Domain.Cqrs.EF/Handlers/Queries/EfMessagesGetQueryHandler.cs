using System.Linq;
using System.Threading.Tasks;

using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query.Message;
using HashtagAggregator.Data.DataAccess.Context;
using HashtagAggregator.Domain.Cqrs.EF.Abstract;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToResult;

using Microsoft.EntityFrameworkCore;

namespace HashtagAggregator.Domain.Cqrs.EF.Handlers.Queries
{
    public class EfMessagesGetQueryHandler : EfQueryHandler<MessagesQuery, MessagesQueryResult>
    {
        public EfMessagesGetQueryHandler(SqlApplicationDbContext context) : base(context)
        {
        }

        protected override async Task<MessagesQueryResult> GetDataAsync(MessagesQuery query)
        {
            var mapper = new EntityToMessagesResultMapper();

            var messages =  await Context.Messages
                .Where(
                        message => message.MessageHashTagRelations.Any(
                            rel => rel.HashTagEntity.HashTag == query.HashTag.NoHashTag)
                   ).ToListAsync();

            return mapper.MapBunch(messages, query.HashTag);
        }
    }
}
