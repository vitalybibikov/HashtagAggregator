using System.Collections.Generic;

namespace MyStudyProject.Core.Contracts.Interface
{
    public interface IMapper<TModel, TEntity>
    {
        TModel Map(TEntity entity, string hashtag);

        IEnumerable<TModel> MapBunch(IEnumerable<TEntity> messages, string hashtag);
    }
}
