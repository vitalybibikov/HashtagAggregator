using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudyProject.Core.Contracts.Interface.Cqrs.Query
{
    public interface IMarkerCompositeQueryHandler<TQuery, TQueryResult> : ICompositeQueryHandler<TQuery, TQueryResult>
     where TQuery : IQuery
     where TQueryResult : IQueryResult
    {

    }
}
