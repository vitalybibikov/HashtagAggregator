using HashtagAggregator.Data.DataAccess.Context;

namespace HashtagAggregator.Domain.Cqrs.EF.Abstract
{
    public abstract class EfQueryHandler
    {
        protected SqlApplicationDbContext Context { get; }

        protected EfQueryHandler(SqlApplicationDbContext context)
        {
            Context = context;
        }
    }
}
