﻿using System;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;

namespace MyStudyProject.Core.Models.Results.Query
{
    public class UserQueryResult : IQueryResult
    {
        public long Id { get; set; }

        public string NetworkId { get; set; }

        public string UserName { get; set; }

        public string ProfileId { get; set; }

        public string Url { get; set; }
    }
}