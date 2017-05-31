﻿using System;
using System.Collections.Generic;

using HashtagAggregator.Core.Models.Interface.Cqrs.Query;
using HashtagAggregator.Core.Models.Results.Query.HashTag;
using HashtagAggregator.Core.Models.Results.Query.User;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Core.Models.Results.Query.Message
{
    public class MessageQueryResult : IQueryResult
    {
        public MessageQueryResult(long id,
            string messageText,
            List<HashTagQueryResult> hashtags,
            SocialMediaType mediaType,
            DateTime? postDate,
            string networkId,
            UserQueryResult user)
        {
            Id = id;
            MessageText = messageText;
            HashTags = hashtags;
            MediaType = mediaType;
            PostDate = postDate;
            NetworkId = networkId;
            User = user;
        }

        public MessageQueryResult()
        {
        }

        public long Id { get; set; }

        public string MessageText { get; set; }

        public List<HashTagQueryResult> HashTags { get; set; }

        public SocialMediaType MediaType { get; set; }

        public DateTime? PostDate { get; set; }

        public string NetworkId { get; set; }

        public UserQueryResult User { get; set; }

        public override bool Equals(object obj)
        {
            var query = obj as MessageQueryResult;
            if (obj == null || query == null || GetType() != query.GetType())
            {
                return false;
            }
            return Id == query.Id
                   && MessageText.Equals(query.MessageText)
                   && MediaType == query.MediaType
                   && PostDate.Equals(query.PostDate)
                   && NetworkId.Equals(query.NetworkId);
        }

        public override int GetHashCode()
        {
            int hashCode = 17;
            hashCode = (hashCode * 23) + Id.GetHashCode();
            hashCode = (hashCode * 23) + MessageText.GetHashCode();
            hashCode = (hashCode * 23) + MediaType.GetHashCode();
            hashCode = (hashCode * 23) + PostDate.GetHashCode();
            hashCode = (hashCode * 23) + NetworkId.GetHashCode();
            return hashCode;
        }
    }
}
