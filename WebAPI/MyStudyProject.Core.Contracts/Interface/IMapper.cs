using System.Collections.Generic;

namespace MyStudyProject.Core.Contracts.Interface
{
    public interface IMapper<in TModel, out TEntity>
    {
        TEntity MapBunch(IEnumerable<TModel> messages, string hashtag);
    }
}
