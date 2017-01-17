using System;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Core.Models.Results.Query
{
    public class MessageQueryResult : IQueryResult
    {
        public MessageQueryResult(long id,
            string body,
            string hashtag,
            SocialMediaType media,
            DateTime? postDate,
            string networkId,
            string userId)
        {
            Id = id;
            Body = body;
            HashTag = hashtag;
            Media = media;
            PostDate = postDate;
            NetworkId = networkId;
            UserId = userId;
        }

        public long Id { get; }

        public string Body { get; }

        public string HashTag { get; }

        public SocialMediaType Media { get; }

        public DateTime? PostDate { get; }

        public string NetworkId { get; }

        public string UserId { get; }


        public override bool Equals(object obj)
        {
            var query = obj as MessageQueryResult;
            if (obj == null || query == null || GetType() != query.GetType())
            {
                return false;
            }
            return Id == query.Id
                   && Body.Equals(query.Body)
                   && HashTag.Equals(query.HashTag)
                   && Media == query.Media
                   && PostDate.Equals(query.PostDate)
                   && NetworkId.Equals(query.NetworkId)
                   && UserId.Equals(query.UserId);
        }

        public override int GetHashCode()
        {
            int hashCode = 17;
            hashCode = (hashCode * 23) + Id.GetHashCode();
            hashCode = (hashCode * 23) + Body.GetHashCode();
            hashCode = (hashCode * 23) + HashTag.GetHashCode();
            hashCode = (hashCode * 23) + Media.GetHashCode();
            hashCode = (hashCode * 23) + PostDate.GetHashCode();
            hashCode = (hashCode * 23) + NetworkId.GetHashCode();
            hashCode = (hashCode * 23) + UserId.GetHashCode();
            return hashCode;
        }
    }
}
