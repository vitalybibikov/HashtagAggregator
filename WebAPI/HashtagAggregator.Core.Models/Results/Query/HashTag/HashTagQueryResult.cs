﻿using HashtagAggregator.Core.Models.Interface.Cqrs.Query;
using HashtagAggregator.Shared.Common.Infrastructure;

namespace HashtagAggregator.Core.Models.Results.Query.HashTag
{
    public class HashTagQueryResult : IQueryResult
    {
        public long Id { get; set; }

        public HashTagWord HashTag { get; set; }

        public bool IsEnabled { get; set; }

        public long? ParentId { get; set; }
    }
}
