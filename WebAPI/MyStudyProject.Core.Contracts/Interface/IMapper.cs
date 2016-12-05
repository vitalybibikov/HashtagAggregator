using System.Collections.Generic;

namespace MyStudyProject.Core.Contracts.Interface
{
    public interface IMapper<out TModel, in TEntity>
    {
        TModel MapBunch(IEnumerable<TEntity> messages, string hashtag);
    }
}
