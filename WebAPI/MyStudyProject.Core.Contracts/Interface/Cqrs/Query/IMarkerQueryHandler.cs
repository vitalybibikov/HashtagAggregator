using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudyProject.Core.Contracts.Interface.Cqrs.Query
{
    public interface IMarkerQueryHandler<in TQuery, TQueryResult> : IQueryHandler<TQuery, TQueryResult>
         where TQuery : IQuery
         where TQueryResult : IQueryResult
    {

    }
}
