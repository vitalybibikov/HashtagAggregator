using System;
using System.Collections.Generic;
using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Data.Internet.Services.Vk;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Data.Internet.Assemblers.Vk
{
    public class VkMessageResultMapper : IMapper<MessagesQueryResult, VkNewsSearchResult>
    {
        public MessagesQueryResult MapBunch(IEnumerable<VkNewsSearchResult> messages, string hashtag)
        {
            var results = new MessagesQueryResult();
            foreach (var post in messages)
            {
                MessageQueryResult message = new MessageQueryResult()
                {
                    Body = post.Text,
                    HashTag = hashtag,
                    Id = post.Id,
                    Media = SocialMediaType.VK,
                    PostDate = DateTimeOffset.FromUnixTimeSeconds(post.UnixTimeStamp).DateTime
                };
                results.Messages.Add(message);
            }
            return results;
        }
    }
}
