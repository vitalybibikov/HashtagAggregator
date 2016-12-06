﻿using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Data.DataAccess.Context;

namespace MyStudyProject.Domain.Cqrs.EF.Abstract
{
    public abstract class EfQueryHandler<TParameter, TResult> : QueryHandler<TParameter, TResult>
         where TResult : IQueryResult, new()
         where TParameter : IQuery
    {
        protected SqlApplicationDbContext Context { get; }

        protected EfQueryHandler(SqlApplicationDbContext context)
        {
            Context = context;
        }
    }
}
