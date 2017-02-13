using System.Collections.Generic;

using MyStudyProject.Core.Models.Interface.Cqrs.Query;

namespace MyStudyProject.Core.Contracts.Interface
{
    public interface IMessageFilter<T>
        where T : IQueryResult, new()
    {
        T Filter(T messages);
    }
}
